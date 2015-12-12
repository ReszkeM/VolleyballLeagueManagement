using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.League.Model
{
    public class BootstrapLeagueContext
    {
        IBus bus;

        public BootstrapLeagueContext(IBus bus)
        {
            this.bus = bus;
        }

        public void RegisterCommandHandlers()
        {
            
        }

        public void RegisterEventHandlers()
        {

        }
    }
}
