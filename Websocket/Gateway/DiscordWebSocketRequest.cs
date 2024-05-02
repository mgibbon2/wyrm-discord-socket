using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyrm_discord.Websocket.Gateway
{
    /// <summary>
    /// This is the base class for a request to the discord
    /// </summary>
    public class DiscordWebSocketRequest<TData>
    {
        public DiscordWebSocketRequest() { }

        public DiscordWebSocketRequest(TData data, OPCODES opCode)
        {
            Data = data;
            OpCode = opCode;
        }
        ///<summary>
        /// The data that will be sent with the request
        /// </summary>
        [JsonProperty("d")]
        public TData Data { get; set; }
        /// <summary>
        /// The opcode that will be sent with the request
        /// </summary>
        [JsonProperty("op")]
        public OPCODES OpCode { get; set; }
    }
}
