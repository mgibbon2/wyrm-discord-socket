using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session
{
    public class PresenceUpdate
    {
        [JsonProperty("since")]
        public int Since { get; set; }

        [JsonProperty("activities")]
        public List<Activity>? Activities { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("afk")]
        public bool Afk { get; set; }
    }

    public class Activity {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
