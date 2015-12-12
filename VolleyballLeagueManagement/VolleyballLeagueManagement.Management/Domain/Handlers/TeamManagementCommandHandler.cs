using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.Management.Domain.Commands;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.Domain.Handlers
{
    public class TeamManagementCommandHandler : 
        IHandler<AddPlayerCommand>,
        IHandler<CreateTeamCommand>,
        IHandler<JoinLeagueCommand>,
        IHandler<RemovePlayerCommand>,
        IHandler<RemoveTeamCommand>,
        IHandler<UpdateCoachCommand>
    {
        public void Handle(AddPlayerCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                Team team = dbContext.Teams.SingleOrDefault(l => l.Id == command.TeamId);
                Player player = CreatePlayerEntity(command, team);

                dbContext.Players.Add(player);
                dbContext.SaveChanges();
            }
        }

        public void Handle(CreateTeamCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                Team team = CreateTeamEntity(command);

                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }
        }

        public void Handle(JoinLeagueCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);
                Team team = dbContext.Teams.SingleOrDefault(l => l.Id == command.TeamId);

                JoinToLeague(league, team);

                dbContext.SaveChanges();
            }
        }

        public void Handle(RemovePlayerCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                Player player = dbContext.Players.SingleOrDefault(l => l.Id == command.PlayerId);

                dbContext.Players.Remove(player);
                dbContext.SaveChanges();
            }
        }

        public void Handle(RemoveTeamCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                Team team = dbContext.Teams.SingleOrDefault(l => l.ManagerId == command.Id);

                dbContext.Teams.Remove(team);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateCoachCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                Team team = dbContext.Teams.SingleOrDefault(l => l.Id == command.TeamId);

                if (team == null || team.Coach == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateCoach(team.Coach, command);
                dbContext.SaveChanges();
            }
        }


        private Player CreatePlayerEntity(AddPlayerCommand command, Team team)
        {
            return new Player
            {
                Team = team,
                TeamId = command.TeamId,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age,
                Growth = command.Growth,
                Position = (Position)command.PositionValue,
                IsCapitan = command.IsCapitan,
            };
        }

        private Team CreateTeamEntity(CreateTeamCommand command)
        {
            return new Team
            {
                Name = command.Name,
                ManagerId = command.ManagerId,
                Status = TeamStatus.LookingForLeague,
                Coach = new Coach
                {
                    FirstName = command.CoachFirstName,
                    LastName = command.CoachLastName,
                    Age = command.CoachAge,
                    Email = command.CoachEmail,
                    Phone = command.CoachPhone
                }
            };
        }

        private void JoinToLeague(League league, Team team)
        {
            league.TeamsWaitingForApprove.Add(team);
            team.League = league;
            team.LeagueId = league.Id;
            team.Status = TeamStatus.WaitingForApprove;
        }

        private void UpdateCoach(Coach coach, UpdateCoachCommand command)
        {
            coach.FirstName = command.CoachFirstName;
            coach.LastName = command.CoachLastName;
            coach.Age = command.CoachAge;
            coach.Email = command.CoachEmail;
            coach.Phone = command.CoachPhone;
        }
    }
}
