using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Rest.Extensions
{
    public class PartialGuild
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("splash")]
        public object Splash { get; set; }

        [JsonProperty("discovery_splash")]
        public object DiscoverySplash { get; set; }

        [JsonProperty("emojis")]
        public List<object> Emojis { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("approximate_member_count")]
        public int ApproximateMemberCount { get; set; }

        [JsonProperty("approximate_presence_count")]
        public int ApproximatePresenceCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stickers")]
        public List<object> Stickers { get; set; }
    }
}
