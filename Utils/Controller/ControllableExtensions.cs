using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Rest;
using wyrm_discord.utils.Controller;

namespace wyrm_discord.Utils.Controller
{
    public static class ControllableExtensions
    {
        /// <summary>
        /// Set the internal client on rest data classes if needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="class"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static T SetClient<T>(this T @class, DiscordClient client) where T : Controllable
        {
            if (@class != null)
                @class.DiscordClient = client;
            return @class!; // ! since you tech can call this without supplying
        }
    }
}
