using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Rest.Extensions
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("guild_id")]
        public string? GuildId { get; set; }

        [JsonProperty("position")]
        public int? Position { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("topic")]
        public string? Topic { get; set; }

        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }
    }
}
