using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;
using VolleyballLeagueManagement.UsersAccounts.Domain.Handlers;

namespace VolleyballLeagueManagement.UsersAccounts.Model
{
    public class BootstrapUserAccountContext
    {
        IBus bus;

        public BootstrapUserAccountContext(IBus bus)
        {
            this.bus = bus;
        }

        public void RegisterCommandHandlers()
        {
            var management = new UserAccountCommandHandler();
            bus.RegisterHandler<AddUserCommand>(management.Handle);
            bus.RegisterHandler<UpdateUserDataCommand>(management.Handle);
            bus.RegisterHandler<RemoveUserCommand>(management.Handle);
            bus.RegisterHandler<UpdateUserAddressCommand>(management.Handle);
            bus.RegisterHandler<ChangeEmailCommand>(management.Handle);
            bus.RegisterHandler<ChangePasswordCommand>(management.Handle);
            bus.RegisterHandler<ChangeUserRoleCommand>(management.Handle);
            bus.RegisterHandler<LogInCommand>(management.Handle);
            bus.RegisterHandler<LogOffCommand>(management.Handle);
        }

        public void RegisterEventHandlers()
        {
            
        }
    }
}
