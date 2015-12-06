using System;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Commands
{
    public class ConfirmAccountCommand : ICommand
    {
        public Guid ConfirmGuid { get; set; }
    }
}
