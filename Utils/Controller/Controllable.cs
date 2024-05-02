using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wyrm_discord.Rest;

namespace wyrm_discord.utils.Controller
{
    public abstract class Controllable : IDisposable
    {
        public DiscordClient? DiscordClient { get; set; }

        public void Dispose()
        {

        }
    }
}
