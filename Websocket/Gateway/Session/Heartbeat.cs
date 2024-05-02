using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway.Session
{
    public class Heartbeat
    {
        [JsonProperty("op")]
        public int OpCode { get; set; }

        [JsonProperty("d")]
        public int Data { get; set; }
    }
}
