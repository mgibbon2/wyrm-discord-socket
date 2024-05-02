using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway
{
    public class DiscordWebSocketMessage : DiscordWebSocketRequest<JToken>
    {
        [JsonProperty("t")]
        public string EventName { get; private set; }

        [JsonProperty("s")]
        public uint? Sequence { get; private set; }
    }
}
