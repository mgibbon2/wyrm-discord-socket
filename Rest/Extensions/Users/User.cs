using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Rest.Extensions.Users;
using wyrm_discord.utils.Controller;

namespace wyrm_discord.Rest.Extensions
{
    public class User : Controllable
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("flags")]
        public int? Flags { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("accent_color")]
        public int? AccentColor { get; set; }

        [JsonProperty("premium_type")]
        public int? PremiumType { get; set; }

        [JsonProperty("public_flags")]
        public int? PublicFlags { get; set; }

        }

    }
