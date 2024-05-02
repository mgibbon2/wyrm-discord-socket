using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.Arm;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Utilities.Log;
using wyrm_discord.Rest;
using wyrm_discord.Rest.Extensions.Users;
using wyrm_discord.Websocket.Gateway;
using wyrm_discord.Websocket.Gateway.EventArgs;
using wyrm_discord.Websocket.Gateway.Session;
using static System.Net.Mime.MediaTypeNames;

namespace wyrm_discord.Websocket {
    public class DiscordSocketClient : DiscordClient {
        public delegate void MessageCreated(DiscordSocketClient client, MessageCreateEventArgs e);
        public event MessageCreated OnMessageCreated = delegate { }; // When you connect to the server

        public delegate void PresenceUpdated(DiscordSocketClient client, PresenceUpdateEventArgs e);
        public event PresenceUpdated OnPresenceUpdated = delegate { };

        public User user { get; private set; }

        // https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.clientwebsocket.-ctor?view=net-8.0
        ClientWebSocket client;
        public DiscordSocketClient(string token) : base(token) {
        }

        /// <summary>
        /// Method that will start the connection to the
        /// gateway for discord and authenticate.
        /// </summary>
        /// <returns></returns>
        public async Task Login() {
            client = new ClientWebSocket();
            try {
                // connect to the server, we dont need a cancellation token
                // because we are not going to cancel the connection
                await client.ConnectAsync(new Uri(Static.GATEWAY), CancellationToken.None);

                await HandleConnection(client);

            }
            catch (Exception e) {
                Logger.LogError(e.Message, "Login");
            }
        }


        /// <summary>
        /// This function will handle the connection to the
        /// gateway and will be responsible for sending and
        /// receiving messages.
        /// </summary>
        /// <param name="client">current handle from socket</param>
        /// <returns></returns>
        private async Task HandleConnection(ClientWebSocket client) {
            try {
                /**
                 * honestly this is aids, discord size for READY is huge
                 * so we need to read the message in chunks and then
                 * combine them together to get the full message
                 */
                const int bufferSize = 4096;
                MemoryStream messageStream = new MemoryStream();

                while (client.State == WebSocketState.Open) {
                    byte[] buffer = new byte[bufferSize];
                    ArraySegment<byte> segment = new ArraySegment<byte>(buffer);

                    WebSocketReceiveResult result = await client.ReceiveAsync(segment, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close) {
                        await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        return;
                    }

                    messageStream.Write(buffer, 0, result.Count);

                    if (result.EndOfMessage) {
                        string message = Encoding.UTF8.GetString(messageStream.ToArray());

                        // Handle the message
                        await HandleMessage(client, JsonConvert.DeserializeObject<DiscordWebSocketMessage>(message));

                        // Reset the stream for the next message
                        messageStream.SetLength(0);
                    }
                }
            }
            catch (Exception e) {
                // Handle exceptions, log, or perform any necessary actions
                Logger.LogError(e.Message, "HandleConnection");
            }
        }


        private async Task HandleMessage(ClientWebSocket client, DiscordWebSocketMessage message) {
            Logger.LogEventStart(message.OpCode.ToString(), "OpCode");
            switch (message.OpCode) {
                case OPCODES.HELLO:
                    Hello helloData = message.Data.ToObject<Hello>();
                    Logger.LogDetails($"Heartbeat Interval: {helloData.HeartbeatInterval} (-1000)", "HandleMessage (OpCode -> Hello)");
                    _ = Task.Run(() =>
                    {
                        int interval = helloData.HeartbeatInterval - 1000;

                        while (true) {
                            Send(OPCODES.HEARTBEAT, message.Sequence);
                            System.Threading.Thread.Sleep(interval);
                            Logger.LogDetails("Heartbeat", "HandleMessage (Hello)");
                        }

                    });
                    await Identify();
                    break;
                case OPCODES.HEARTBEAT:
                    // handle heartbeat
                    Heartbeat heartbeatData = message.Data.ToObject<Heartbeat>();
                    Logger.LogDetails($"Operation: {heartbeatData.OpCode}", "HandleMessage (OpCode -> Heartbeat)");
                    Logger.LogDetails($"Data: {heartbeatData.Data}", "HandleMessage (OpCode -> Heartbeat)");
                    break;
                case OPCODES.HEARTBEAT_ACK:
                    Logger.LogDetails("Heartbeat Acknowledged", "HandleMessage (OpCode -> Heartbeat_Ack)");
                    break;
                case OPCODES.IDENTIFY:
                    // handle identify
                    Identify identifyData = message.Data.ToObject<Identify>();
                    Logger.LogDetails($"Token: {identifyData.Token}", "HandleMessage (OpCode -> Identify)");
                    if (identifyData.Properties != null) {
                        Logger.LogDetails($"OS: {identifyData.Properties.OS}", "HandleMessage (OpCode -> Identify)");
                        Logger.LogDetails($"Browser: {identifyData.Properties.Browser}", "HandleMessage (OpCode -> Identify)");
                        Logger.LogDetails($"Device: {identifyData.Properties.Device}", "HandleMessage (OpCode -> Identify)");
                    }
                    Logger.LogDetails($"Compress: {identifyData.Compress}", "HandleMessage (OpCode -> Identify)");
                    Logger.LogDetails($"Large Threshold: {identifyData.LargeThreshold}", "HandleMessage (OpCode -> Identify)");
                    if (identifyData.Shard != null) {
                        Logger.LogDetails($"Shard ID: {identifyData.Shard[0]}", "HandleMessage (OpCode -> Identify)");
                        Logger.LogDetails($"Total Shards: {identifyData.Shard[1]}", "HandleMessage (OpCode -> Identify)");
                    }
                    Logger.LogDetails($"Presence: {identifyData.Presence}", "HandleMessage (OpCode -> Identify)");
                    Logger.LogDetails($"Intents: {identifyData.Intents}", "HandleMessage (OpCode -> Identify)");
                    break;
                case OPCODES.PRESENCE_UPDATE:
                    // handle presence update
                    PresenceUpdate presenceUpdateData = message.Data.ToObject<PresenceUpdate>();
                    Logger.LogDetails($"Since: {presenceUpdateData.Since}", "HandleMessage (OpCode -> PresenceUpdate)");
                    Logger.LogDetails($"Status: {presenceUpdateData.Status}", "HandleMessage (OpCode -> PresenceUpdate)");
                    Logger.LogDetails($"AFK: {presenceUpdateData.Afk}", "HandleMessage (OpCode -> PresenceUpdate)");
                    if (presenceUpdateData.Activities != null) {
                        foreach (Activity activity in presenceUpdateData.Activities) {
                            Logger.LogDetails($"Activity Name: {activity.Name}, Type: {activity.Type}", "HandleMessage (OpCode -> PresenceUpdate)");
                        }
                    }
                    break;
                case OPCODES.VOICE_STATE_UPDATE:
                    // handle voice state update
                    VoiceStateUpdate voiceStateUpdateData = message.Data.ToObject<VoiceStateUpdate>();
                    Logger.LogDetails($"Guild ID: {voiceStateUpdateData.GuildId}", "HandleMessage (OpCode -> VoiceStateUpdate)");
                    Logger.LogDetails($"Channel ID: {voiceStateUpdateData.ChannelId}", "HandleMessage (OpCode -> VoiceStateUpdate)");
                    Logger.LogDetails($"Self Mute: {voiceStateUpdateData.SelfMute}", "HandleMessage (OpCode -> VoiceStateUpdate)");
                    Logger.LogDetails($"Self Deaf: {voiceStateUpdateData.SelfDeaf}", "HandleMessage (OpCode -> VoiceStateUpdate)");
                    break;
                case OPCODES.RESUME:
                    // handle resume
                    Resume resumeData = message.Data.ToObject<Resume>();
                    Logger.LogDetails($"Token: {resumeData.Token}", "HandleMessage (OpCode -> Resume)");
                    Logger.LogDetails($"Session ID: {resumeData.SessionId}", "HandleMessage (OpCode -> Resume)");
                    Logger.LogDetails($"Sequence: {resumeData.Sequence}", "HandleMessage (OpCode -> Resume)");
                    break;
                case OPCODES.DISPATCH:
                    // handle dispatch
                    // this is the 2nd switch statement
                    // this will be the event name
                    // see: https://github.com/discord-net/Discord.Net/blob/dev/src/Discord.Net.WebSocket/DiscordSocketClient.cs
                    // MVP dispatch types: MESSAGE_CREATE, PRESENCE_UPDATE
                    /* possible dispatch types:
                     * connection
                     * READY, RESUMED
                     * 
                     * guilds
                     * GUILD_CREATE, GUILD_UPDATE, GUILD_EMOJIS_UPDATE, GUILD_SYNC, GUILD_DELETE, GUILD_STICKETS_UPDATE
                     * 
                     * channels
                     * CHANNEL_CREATE, CHANNEL_UPDATE, CHANNEL_DELETE, CHANNEL_PINS_ACK, CHANNEL_PINS_UPDATE
                     * 
                     * members
                     * GUILD_MEMBER_ADD, GUILD_MEMBER_UPDATE, GUILD_MEMBER_REMOVE, GUILD_MEMBERS_CHUNK, 
                     * GUILD_JOIN_REQUEST_DELETE, GUILD_INTERACTIONS_UPDATE
                     * 
                     * dm channels
                     * CHANNEL_RECIPIENT_ADD, CHANNEL_RECIPIENT_REMOVE
                     * 
                     * roles
                     * GUILD_ROLE_CREATE, GUILD_ROLE_UPDATE, GUILD_ROLE_DELETE
                     * 
                     * bans
                     * GUILD_BAN_ADD, GUILD_BAN_REMOVE
                     * 
                     * messages
                     * MESSAGE_CREATE, MESSAGE_UPDATE, MESSAGE_DELETE, MESSAGE_REACTION_ADD, MESSAGE_REACTION_REMOVE, 
                     * MESSAGE_REACTION_REMOVE_ALL, MESSAGE_REACTION_REMOVE_EMOJI, MESSAGE_DELETE_BULK, MESSAGE_ACK
                     * 
                     * statuses
                     * PRESENCE_UPDATE, PRESENCE_REPLACE, TYPING_START
                     * 
                     * integrations
                     * INTEGRATION_CREATE, INTEGRATION_UPDATE, INTEGRATION_DELETE
                     * 
                     * users
                     * USER_UPDATE, USER_SETTINGS_UPDATE
                     * 
                     * voice
                     * VOICE_STATE_UPDATE, VOICE_SERVER_UPDATE, VOICE_CHANNEL_STATUS_UPDATE
                     * 
                     * invites
                     * INVITE_CREATE, INVITE_DELETE
                     * 
                     * interactions
                     * INTERACTION_CREATE, APPLICATION_COMMAND_CREATE, APPLICATION_COMMAND_UPDATE, APPLICATION_COMMAND_DELETE
                     * 
                     * threads
                     * THREAD_CREATE, THREAD_UPDATE, THREAD_DELETE, THREAD_LIST_SYNC, THREAD_MEMBER_UPDATE, THREAD_MEMBERS_UPDATE
                     * 
                     * stage channels
                     * STAGE_INSTANCE_CREATE, STAGE_INSTANCE_UPDATE, STAGE_INSTANCE_DELETE
                     * 
                     * guild scheduled events
                     * GUILD_SCHEDULED_EVENT_CREATE, GUILD_SCHEDULED_EVENT_UPDATE, GUILD_SCHEDULED_EVENT_DELETE,
                     * GUILD_SCHEDULED_EVENT_USER_ADD, GUILD_SCHEDULED_EVENT_USER_REMOVE
                     * 
                     * webhooks
                     * WEBHOOKS_UPDATE
                     * 
                     * audit logs
                     * GUILD_AUDIT_LOG_ENTRY_CREATE
                     * 
                     * auto moderation
                     * AUTO_MODERATION_RULE_CREATE, AUTO_MODERATION_RULE_UPDATE, AUTO_MODERATION_RULE_DELETE, AUTO_MODEATION_ACTION_EXECUTION
                     * 
                     * app subscriptions
                     * ENTITLEMENT_CREATE, ENTITLEMENT_UPDATE, ENTITLEMENT_DELETE
                     */
                    Logger.LogEventStart(message.EventName, "Dispatch");
                    switch (message.EventName) {
                        case "READY":
                            // handle ready
                            Ready ready = message.Data.ToObject<Ready>();

                            Logger.LogDetails($"Username: {ready.User.Username}", "HandleMessage (Ready)");
                            user = ready.User;
                            break;
                        case "MESSAGE_CREATE":
                            // handle message create
                            MessageCreate messageCreateData = message.Data.ToObject<MessageCreate>();
                            MessageCreateEventArgs messageCreateEventArgs = new MessageCreateEventArgs(messageCreateData);
                            OnMessageCreated.Invoke(this, messageCreateEventArgs);
                            break;
                        case "PRESENCE_UPDATE":
                            // handle presence update
                            PresenceUpdate dispatchPresenceUpdateData = message.Data.ToObject<PresenceUpdate>();
                            PresenceUpdateEventArgs presenceUpdateEventArgs = new PresenceUpdateEventArgs(dispatchPresenceUpdateData);
                            OnPresenceUpdated.Invoke(this, presenceUpdateEventArgs);
                            break;
                        default:
                            Logger.LogWarning($"Unknown Dispatch Event Name: {message.EventName}", "HandleMessage (Dispatch)");
                            break;
                    }
                    Logger.LogEventOver(message.EventName, "Dispatch");
                    break;
                default:
                    Logger.LogWarning($"Unknown OpCode Event Name: {message.OpCode}", "HandleMessage (OpCode)");
                    break;
            }
            Logger.LogEventOver(message.OpCode.ToString(), "OpCode");
        }


        /// <summary>
        /// Send data to the gateway
        /// </summary>
        /// <typeparam name="T">
        /// the type of data to send
        /// </typeparam>
        /// <param name="opCode">
        /// opcode to send to the gateway
        /// </param>
        /// <param name="data">
        /// the data/payload to send to the gateway
        /// </param>
        private async void Send<T>(OPCODES opCode, T data) {
            // TODO add cooldown wait Cooldown = DateTime.Now + new TimeSpan(0, 0, 0, 0, 500);
            var message = JsonConvert.SerializeObject(new DiscordWebSocketRequest<T>(data, opCode));

            // send the message
            await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), WebSocketMessageType.Text, true, CancellationToken.None);

            Logger.LogEvent("Send Payload", "Send");
        }

        private async Task Identify() {
            // TODO add cooldown wait Cooldown = DateTime.Now + new TimeSpan(0, 0, 0, 0, 500);
            var message = JsonConvert.SerializeObject(new DiscordWebSocketRequest<Identify>(new Identify()
            {
                Token = _token,
                Properties = new IdentifyConnection()
                {
                    OS = "windows",
                    Browser = "acce",
                    Device = "acce"
                },
                Compress = false,
                LargeThreshold = "50",

            }, OPCODES.IDENTIFY),
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            var payload = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));

            // send the message
            await client.SendAsync(payload, WebSocketMessageType.Text, true, CancellationToken.None);

        }

    }
}
