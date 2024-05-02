using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session
{
    public class Resume {
        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("session_id")]
        public string? SessionId { get; set; }

        [JsonProperty("seq")]
        public int Sequence { get; set; }
    }
}
