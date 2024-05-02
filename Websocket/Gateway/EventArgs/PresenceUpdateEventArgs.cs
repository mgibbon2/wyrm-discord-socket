using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Websocket.Gateway.Session;

namespace wyrm_discord.Websocket.Gateway.EventArgs {
    public class PresenceUpdateEventArgs : PresenceUpdate {

        public PresenceUpdateEventArgs() {

        }

        public PresenceUpdateEventArgs(PresenceUpdate presenceUpdate) {
            this.Since = presenceUpdate.Since;
            this.Activities = presenceUpdate.Activities;
            this.Status = presenceUpdate.Status;
            this.Afk = presenceUpdate.Afk;
        }
    }
}
