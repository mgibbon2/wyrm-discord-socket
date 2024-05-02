using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Http;
using wyrm_discord.Rest.Extensions.Guilds;
using wyrm_discord.Utils.Controller;

namespace wyrm_discord.Rest.Extensions.Users
{
    public static class Extensions
    {



        /// <summary>
        /// Return user obeject of requester account
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        public static User GetUser(this DiscordClient client)
        {
            return client.Get<User>("/users/@me").Result.SetClient(client);
        }


        /// <summary>
        /// This gets a list of partial guild objects for the requestor
        /// </summary>
        /// <param name="client">
        /// This is auto filled by the extension method
        /// </param>
        public static PartialGuild[] GetGuilds(this DiscordClient client)
        {
            return client.Get<PartialGuild[]>("/users/@me/guilds").Result;
        }




        
    }
}
