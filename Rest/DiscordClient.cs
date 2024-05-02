using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.Http;
using Utilities.Http.Humanize;
using wyrm_discord.Rest.Extensions.Humanize;


namespace wyrm_discord.Rest
{
    public class DiscordClient : IHttpClient
    {
        /// <summary>
        /// token for the discord account
        /// </summary>
        protected internal string _token;
        public RestClient       RestClient  { get; set; }   = new("https://discord.com/api/v9");
        public UserAgentHandler UserAgent   { get; }        = new UserAgentHandler(AGENTTYPE.CHROME);


        public DiscordClient(string token)
        {



            _token = token;


            Console.WriteLine("adding default headers");
            RestClient.AddDefaultHeader("Authorization", $"{_token}");
            RestClient.AddDefaultHeader("Host", "discord.com");
            RestClient.AddDefaultHeader("User-Agent", UserAgent.ToString());
            RestClient.AddDefaultHeader("X-Super-Properties", UserAgent.BuildXSuperProperties());
            RestClient.AddDefaultHeader("X-Discord-Locale", "en-US");
            RestClient.AddDefaultHeader("X-Discord-Timezone", "America/Denver");
            RestClient.AddDefaultHeader("X-Debug-Options", "bugReporterEnabled");
            RestClient.AddDefaultHeader("Connection", "keep-alive");
            RestClient.AddDefaultHeader("Referer", "https://discord.com/channels/@me");
            RestClient.AddDefaultHeader("Cookie", this.GetCookies());
            RestClient.AddDefaultHeader("Sec-Fetch-Dest", "empty");
            RestClient.AddDefaultHeader("Sec-Fetch-Mode", "cors");
            RestClient.AddDefaultHeader("Sec-Fetch-Site", "same-origin");
            RestClient.AddDefaultHeader("TE", "trailers");


        }

    }
}
