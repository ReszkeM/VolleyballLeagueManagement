using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.League.Domain.Commands;
using VolleyballLeagueManagement.League.Domain.Handlers;

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
            var messaging = new LeagueCommandHandler();
            bus.RegisterHandler<UpdateGameResultCommand>(messaging.Handle);
            bus.RegisterHandler<UpdateGameDateCommand>(messaging.Handle);
            bus.RegisterHandler<GenerateCalendarCommand>(messaging.Handle);
        }

        public void RegisterEventHandlers()
        {

        }
    }
}
