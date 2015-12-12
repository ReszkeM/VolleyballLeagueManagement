using System.Linq;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.Management.Domain.Commands;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.Domain.Handlers
{
    public class MessagingCommandHandler : 
        IHandler<AddLeagueNoteCommand>,
        IHandler<SendMessageCommand>
    {
        public void Handle(AddLeagueNoteCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);
                LeagueNote note = CreateNoteEntity(command, league);

                dbContext.LeagueMessages.Add(note);
                dbContext.SaveChanges();
            }
        }

        public void Handle(SendMessageCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                // TODO

                dbContext.SaveChanges();
            }
        }


        private LeagueNote CreateNoteEntity(AddLeagueNoteCommand command, League league)
        {
            return new LeagueNote
            {
                League = league,
                LeagueId = command.LeagueId,
                Title = command.Title,
                Message = command.Message
            };
        }
    }
}
