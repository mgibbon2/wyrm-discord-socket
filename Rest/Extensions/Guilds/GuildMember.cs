using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Rest.Extensions.Guilds
{
    public class GuildMember
    {
        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("nick")]
        public string? Nick { get; set; }

        [JsonProperty("avatar")]
        public object? Avatar { get; set; }

        [JsonProperty("roles")]
        public List<object> Roles { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("premium_since")]
        public DateTime? PremiumSince { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("pending")]
        public bool? Pending { get; set; }

        [JsonProperty("permissions")]
        public string? Permissions { get; set; }

        [JsonProperty("communication_disabled_until")]
        public DateTime? CommunicationDisabledUntil { get; set; }
    }
}
