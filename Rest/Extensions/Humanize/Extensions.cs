using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Http;
using Utilities.Log;
using wyrm_discord.Rest.Extensions.Users;

namespace wyrm_discord.Rest.Extensions.Humanize
{
    internal static class Extensions
    {

        // TODO finish this
        public static string GetCookies(this DiscordClient client)
        {
            Console.WriteLine($"spoofing cookies for UA: {client.UserAgent.UserAgent}");
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authority", "discord.com");
            headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            headers.Add("accept-language", "en-US,en;q=0.9");
            headers.Add("sec-ch-ua", $"\"{client.UserAgent.ToBrowser}\";v=\"{client.UserAgent.ToVersion}\", \"Not;A=Brand\";v=\"8\", \"Chromium\";v=\"{client.UserAgent.ToVersion()}\"");
            headers.Add("sec-ch-ua-mobile", "?0");
            headers.Add("sec-ch-ua-platform", $"\"{client.UserAgent.ToOs}\"");
            headers.Add("sec-fetch-dest", "document");
            headers.Add("sec-fetch-mode", "navigate");
            headers.Add("sec-fetch-site", "none");
            headers.Add("sec-fetch-user", "?1");
            headers.Add("upgrade-insecure-requests", "1");
            headers.Add("user-agent", client.UserAgent.ToString());
            var cookies = client.Get<Dispose>($"https://discord.com/register", headers ,true).Cookies;
            string addedCookies = "";
            Logger.LogEvent("Getting Cookies", "GetCookies");
            foreach (var cookie in cookies)
            {
                Logger.LogDetails($"{cookie.Key}={cookie.Value}", "GetCookies");
                addedCookies += $"{cookie.Key}={cookie.Value}; ";
            }
            addedCookies = addedCookies.Remove(addedCookies.Length - 1);
            return addedCookies;
        }
    }
}
