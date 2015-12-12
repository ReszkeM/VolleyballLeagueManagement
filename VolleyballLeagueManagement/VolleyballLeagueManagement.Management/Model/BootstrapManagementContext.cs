using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.Management.Domain.Commands;
using VolleyballLeagueManagement.Management.Domain.Handlers;

namespace VolleyballLeagueManagement.Management.Model
{
    public class BootstrapManagementContext
    {
        IBus bus;

        public BootstrapManagementContext(IBus bus)
        {
            this.bus = bus;
        }

        public void RegisterCommandHandlers()
        {
            var leagueManagement = new LeagueManagementCommandHandler();
            bus.RegisterHandler<CreateLeagueCommand>(leagueManagement.Handle);
            bus.RegisterHandler<RemoveLeagueCommand>(leagueManagement.Handle);
            bus.RegisterHandler<UpdateSportsHallCommand>(leagueManagement.Handle);
            bus.RegisterHandler<UpdateLeagueInformationsCommand>(leagueManagement.Handle);
            bus.RegisterHandler<UpdateLeagueStatusCommand>(leagueManagement.Handle);
            bus.RegisterHandler<UpdateRegulationsCommand>(leagueManagement.Handle);
            bus.RegisterHandler<UpdateTableOrderRulesCommand>(leagueManagement.Handle);

            var teamManagement = new TeamManagementCommandHandler();
            bus.RegisterHandler<AddPlayerCommand>(teamManagement.Handle);
            bus.RegisterHandler<CreateTeamCommand>(teamManagement.Handle);
            bus.RegisterHandler<JoinLeagueCommand>(teamManagement.Handle);
            bus.RegisterHandler<UpdateCoachCommand>(teamManagement.Handle);
            bus.RegisterHandler<RemovePlayerCommand>(teamManagement.Handle);
            bus.RegisterHandler<RemoveTeamCommand>(teamManagement.Handle);

            var messaging = new MessagingCommandHandler();
            bus.RegisterHandler<AddLeagueNoteCommand>(messaging.Handle);
            bus.RegisterHandler<SendMessageCommand>(messaging.Handle);
        }

        public void RegisterEventHandlers()
        {

        }
    }
}
