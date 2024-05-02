using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session
{
    public class Identify
    {
        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("properties")]
        public IdentifyConnection? Properties { get; set; }

        [JsonProperty("compress")]
        public bool Compress { get; set; }

        [JsonProperty("large_threshold")]
        public string? LargeThreshold { get; set; }

        // shard has 2 values, the shard id and the total number of shards
        [JsonProperty("shard")]
        public int[]? Shard { get; set; }

        // todo presence object
        [JsonProperty("presence")]
        public string? Presence { get; set; }

        /// <summary>
        /// Leave ths blank for user accounts
        /// </summary>
        [JsonProperty("intents")]
        public int? Intents { get; set; } 
    }

    public class IdentifyConnection
    {
        [JsonProperty("os")]
        public string? OS { get; set; }

        [JsonProperty("browser")]
        public string? Browser { get; set; }

        [JsonProperty("device")]
        public string? Device { get; set; }
    }
}
