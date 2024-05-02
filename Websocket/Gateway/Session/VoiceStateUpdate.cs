using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session
{
    public class VoiceStateUpdate {
        [JsonProperty("token")]
        public string? GuildId { get; set; }

        [JsonProperty("channel_id")]
        public string? ChannelId { get; set; }

        [JsonProperty("self_mute")]
        public bool SelfMute { get; set; }

        [JsonProperty("self_deaf")]
        public bool SelfDeaf { get; set; }
    }
}
