using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Rest.Extensions
{
    public class Guild
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("splash")]
        public object Splash { get; set; }

        [JsonProperty("discovery_splash")]
        public object DiscoverySplash { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("emojis")]
        public List<object> Emojis { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("application_id")]
        public object ApplicationId { get; set; }

        [JsonProperty("region")]
        public object Region { get; set; }

        [JsonProperty("afk_channel_id")]
        public object AfkChannelId { get; set; }

        [JsonProperty("afk_timeout")]
        public int AfkTimeout { get; set; }

        [JsonProperty("system_channel_id")]
        public object SystemChannelId { get; set; }

        [JsonProperty("widget_enabled")]
        public bool WidgetEnabled { get; set; }

        [JsonProperty("widget_channel_id")]
        public object WidgetChannelId { get; set; }

        [JsonProperty("verification_level")]
        public int VerificationLevel { get; set; }

        [JsonProperty("roles")]
        public List<object> Roles { get; set; }

        [JsonProperty("default_message_notifications")]
        public int DefaultMessageNotifications { get; set; }

        [JsonProperty("mfa_level")]
        public int MfaLevel { get; set; }

        [JsonProperty("explicit_content_filter")]
        public int ExplicitContentFilter { get; set; }

        [JsonProperty("max_presences")]
        public int MaxPresences { get; set; }

        [JsonProperty("max_members")]
        public int MaxMembers { get; set; }

        [JsonProperty("vanity_url_code")]
        public string VanityUrlCode { get; set; }

        [JsonProperty("premium_tier")]
        public int PremiumTier { get; set; }

        [JsonProperty("premium_subscription_count")]
        public int PremiumSubscriptionCount { get; set; }

        [JsonProperty("system_channel_flags")]
        public int SystemChannelFlags { get; set; }

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("rules_channel_id")]
        public string RulesChannelId { get; set; }

        [JsonProperty("public_updates_channel_id")]
        public string PublicUpdatesChannelId { get; set; }

        [JsonProperty("safety_alerts_channel_id")]
        public string SafetyAlertsChannelId { get; set; }
    }
}
