using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket
{

        public enum OPCODES
        {
            /// <summary>
            /// Reveive
            /// An event was dispatched.
            /// </summary>
            DISPATCH = 0,
            /// <summary>
            /// Send/Receieve
            /// Fired preriodically by the client to keep the connection alive.
            /// </summary>
            HEARTBEAT = 1,
            /// <summary>
            /// Send
            /// Starts a new session durin the initial handshake.
            /// </summary>
            IDENTIFY = 2,
            /// <summary>
            /// Send
            /// Updates the client's presence.
            /// </summary>
            PRESENCE_UPDATE = 3,
            /// <summary>
            /// Send
            /// Used to join/leave or move between voice channels.
            /// </summary>
            VOICE_STATE_UPDATE = 4,
            /// <summary>
            /// Send
            /// Resume a previous session that was disconnected.
            /// </summary>
            RESUME = 6,
            /// <summary>
            /// Receive
            /// You should attemp to reconnect and resume immediately.
            /// </summary>
            RECONNECT = 7,
            /// <summary>
            /// Send
            /// Request information about offline guild members in a large guild.
            /// </summary>
            REQUEST_GUILD_MEMBERS = 8,
            /// <summary>
            /// Receive
            /// The session has been invalidated. You should reconnect and indetify/resume accordingly.
            /// </summary>
            INVALID_SECTION = 9,
            /// <summary>
            /// Receive
            /// Sent immediately after connecting, contains that heartbeat_interval to use.
            /// </summary>
            HELLO = 10,
            /// <summary>
            /// Receive
            /// Sent in response to receiving a heartbeat to acknowledge that it has been receieved.
            /// </summary>
            HEARTBEAT_ACK = 11
        }
    public static class Static
    {

        public static string GATEWAY = "wss://gateway.discord.gg/?v10&encoding=json";
    }
}
