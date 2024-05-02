using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Rest.Extensions;
using Utilities.Http;

namespace wyrm_discord.Rest.Extensions.Guilds
{
    public static class Extensions
    {
        /// <summary>
        /// Returns the guild object
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static Guild GetGuild(this DiscordClient client, ulong id)
        {
            return client.Get<Guild>($"/guilds/{id}/").Result;
        }

        /// <summary>
        /// Returns all the channels in the guild as Channel Objects
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static Channel GetGuildChannels(this DiscordClient client, ulong id)
        {
            return client.Get<Channel>($"/guilds/{id}/channels").Result;
        }

        /// <summary>
        /// Returns all active threads in the guild
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static Guild[] GetActiveGuilds(this DiscordClient client, ulong id)
        {
            return client.Get<Guild[]>($"/guilds/{id}/threads/active").Result;
        }


        /// <summary>
        /// Returns the GuildMember object information about a specific user from a guild.
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="GuildId">
        /// This is the Guild Id
        /// </param>
        /// <param name="UserId">
        /// This is the User Id
        /// </param>
        public static GuildMember GetGuildMembers(this DiscordClient client, ulong GuildId, ulong UserId)
        {
            return client.Get<GuildMember>($"/guilds/{GuildId}/members/{UserId}").Result;
        }

        /// <summary>
        /// Gives a list of users in the guild with their Guild Member object
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static GuildMember[] GetListGuildMember(this DiscordClient client, ulong id)
        {

            return client.Get<GuildMember[]>($"/guilds/{id}/members").Result;
        }

        /// <summary>
        /// Search for a specific member of the a guild using a string
        /// https://discord.com/developers/docs/resources/guild#search-guild-members
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static GuildMember[] GetSearchGuildMember(this DiscordClient client, ulong id)
        {
            return client.Get<GuildMember[]>($"/guilds/{id}/members/search").Result;
        }

        /// <summary>
        /// List of roles from a specific guild
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        /// <param name="id">
        /// This is the id of the guild you want to reference
        /// </param>
        public static Roles[] GetGuildRoles(this DiscordClient client, ulong id)
        {
            return client.Get<Roles[]>($"/guilds/{id}/roles").Result;
        }


    }
}
