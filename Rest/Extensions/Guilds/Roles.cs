using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Rest.Extensions.Guilds
{
    public class Roles
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("hoist")]
        public bool Hoist { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }

        [JsonProperty("unicode_emoji")]
        public object? UnicodeEmoji { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("mentionable")]
        public bool Mentionable { get; set; }

        //https://discord.com/developers/docs/topics/permissions#role-object-role-tags-structure
        [JsonProperty("tags")]
        public RoleTag? Tags { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

    }

    public class RoleTag
    {
        [JsonProperty("bot_id")]
        public string? BotId { get; set; }

        [JsonProperty("integration_id")]
        public string? IntegrationsId { get; set; }

        [JsonProperty("premium_subscriber")]
        public bool? PremiumSubscriber { get; set; }

        [JsonProperty("subscription_listing_id")]
        public string? SubscriptionListingId { get; set; }

        [JsonProperty("available_for_purchase")]
        public bool? AvailableForPurchase { get; set; }

        [JsonProperty("guild_connections")]
        public bool? GuildConnections { get; set; }
    }
}
