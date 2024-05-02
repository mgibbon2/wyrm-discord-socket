using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Rest.Extensions;

namespace wyrm_discord.Rest.Extensions
{
    public class Invite
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("guild")]
        public Guild? guild { get; set; }

        // TODO: Implement Channel
        //[JsonProperty("channel")]
        // public Channel? Channel { get; set; }

        [JsonProperty("inviter")]
        public User? Inviter { get; set; }

        [JsonProperty("target_type")]
        public TargetType? TargetType { get; set; }

        [JsonProperty("target_user")]
        public User? TargetUser { get; set; }

        // TODO: implement ApplicationPartial
        //[JsonProperty("target_application")]
        //public ApplicationPartial? TargetApplication { get; set; }

        [JsonProperty("approximate_presence_count")]
        public int? ApproximatePresenceCount { get; set; }

        [JsonProperty("approximate_member_count")]
        public int? ApproximateMemberCount { get; set; }
        
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        //[JsonProperty("stage_instance")]
        //public StageInstance? StageInstance { get; set; }

        //[JsonProperty("guild_scheduled_event")]
        //public GuildScheduledEvent? GuildScheduledEvent { get; set; }

    }

    public enum TargetType
    {
        STREAM = 1,
        EMBEDDED_APPLICATION = 2
    }
}
