using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session {
    public class MessageCreate {

        [JsonProperty("guild_id")]
        public ulong? GuildId { get; set; }

        [JsonProperty("member")]
        public object? Member { get; set; }

        [JsonProperty("mentions")]
        public object[]? Mentions { get; set; }
    }
}
