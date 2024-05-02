using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Websocket.Gateway.Session;

namespace wyrm_discord.Websocket.Gateway.EventArgs {
    public class MessageCreateEventArgs : MessageCreate {

        public MessageCreateEventArgs() {

        }

        public MessageCreateEventArgs(MessageCreate messageCreate) {
            this.GuildId = messageCreate.GuildId;
            this.Member = messageCreate.Member;
            this.Mentions = messageCreate.Mentions;
        }
    }
}
