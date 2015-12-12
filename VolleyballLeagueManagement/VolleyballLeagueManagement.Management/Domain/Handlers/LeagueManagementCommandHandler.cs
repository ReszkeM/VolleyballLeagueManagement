using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.Management.Domain.Commands;
using VolleyballLeagueManagement.Management.Model;

namespace VolleyballLeagueManagement.Management.Domain.Handlers
{
    public class LeagueManagementCommandHandler : 
        IHandler<CreateLeagueCommand>,
        IHandler<RemoveLeagueCommand>,
        IHandler<UpdateSportsHallCommand>,
        IHandler<UpdateLeagueInformationsCommand>,
        IHandler<UpdateLeagueStatusCommand>,
        IHandler<UpdateRegulationsCommand>,
        IHandler<UpdateTableOrderRulesCommand>,
        IHandler<UpdateTeamStatusCommand>
    {
        public void Handle(CreateLeagueCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = CreateLeagueEntity(command);

                dbContext.Leagues.Add(league);
                dbContext.SaveChanges();
            }
        }

        public void Handle(RemoveLeagueCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.FirstOrDefault(l => l.OrganizerId == command.Id);

                dbContext.Leagues.Remove(league);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateSportsHallCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);

                if (league == null || league.SportsHall == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateSportsHall(league.SportsHall, command);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateLeagueInformationsCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);

                if (league == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateLeagueInformations(league, command);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateLeagueStatusCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);

                if (league == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                league.UpdateStatus(command.Status);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateRegulationsCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);

                if (league == null || league.Regulations == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateRegulations(league.Regulations, command);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateTableOrderRulesCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);

                if (league == null || league.Regulations == null || league.Regulations.TableOrderRules == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateTableOrderRules(league.Regulations.TableOrderRules, command);
                dbContext.SaveChanges();
            }
        }

        public void Handle(UpdateTeamStatusCommand command)
        {
            // TODO validate

            using (var dbContext = new ManagementDataContext())
            {
                League league = dbContext.Leagues.SingleOrDefault(l => l.Id == command.LeagueId);
                Team team = dbContext.Teams.SingleOrDefault(l => l.Id == command.TeamId);

                if (league == null || league.TeamsWaitingForApprove == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                if (team == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateTeamStatus(league, team, command.Accept);
                dbContext.SaveChanges();
            }
        }


        private League CreateLeagueEntity(CreateLeagueCommand command)
        {
            return new League
            {
                Name = command.Name,
                Description = command.Description,
                AdditionalInformations = command.AdditionalInformations,
                Status = LeagueStatus.WaitingForTeams,
                OrganizerId = command.ManagerId,
                SportsHall = new SportsHall
                {
                    City = command.City,
                    Streat = command.Streat,
                    Number = command.Number,
                    PostCode = command.PostCode,
                    Email = command.Email,
                    Phone = command.Phone
                },
                Regulations = new Regulations
                {
                    ApplicationDeadline = command.ApplicationDeadline,
                    StartTime = command.StartTime,
                    EndTime = command.EndTime,
                    EntryFee = command.EntryFee,
                    PlayersLimit = command.PlayersLimit,
                    Playoffs = command.Playoffs,
                    TeamsLimit = command.TeamsLimit,
                    TableOrderRules = new TableOrderRules
                    {
                        FirstRule = command.FirstRule,
                        SecondRule = command.SecondRule,
                        ThirdRule = command.ThirdRule,
                        FourthRule = command.FourthRule,
                        FifthRule = command.FifthRule
                    }
                }
            };
        }

        public void UpdateSportsHall(SportsHall sportsHall, UpdateSportsHallCommand command)
        {
            sportsHall.City = command.City;
            sportsHall.Streat = command.Streat;
            sportsHall.Number = command.Number;
            sportsHall.Phone = command.Phone;
            sportsHall.Email = command.Email;
            sportsHall.PostCode = command.PostCode;
        }

        private void UpdateLeagueInformations(League league, UpdateLeagueInformationsCommand command)
        {
            league.Name = command.Name;
            league.Description = command.Description;
            league.AdditionalInformations = command.AdditionalInformations;
        }

        private void UpdateRegulations(Regulations regulations, UpdateRegulationsCommand command)
        {
            regulations.ApplicationDeadline = command.ApplicationDeadline;
            regulations.StartTime = command.StartTime;
            regulations.EndTime = command.EndTime;
            regulations.EntryFee = command.EntryFee;
            regulations.TeamsLimit = command.TeamsLimit;
            regulations.PlayersLimit = command.PlayersLimit;
            regulations.Playoffs = command.Playoffs;
        }

        private void UpdateTableOrderRules(TableOrderRules tableOrderRules, UpdateTableOrderRulesCommand command)
        {
            tableOrderRules.FirstRule = command.FirstRule;
            tableOrderRules.SecondRule = command.SecondRule;
            tableOrderRules.ThirdRule = command.ThirdRule;
            tableOrderRules.FourthRule = command.FourthRule;
            tableOrderRules.FifthRule = command.FifthRule;
        }

        private void UpdateTeamStatus(League league, Team team, bool accept)
        {
            if (accept)
            {
                league.TeamsWaitingForApprove.Remove(team);
                league.Teams.Add(team);
                team.Status = TeamStatus.Approved;
            }
            else
            {
                league.TeamsWaitingForApprove.Remove(team);
                team.League = null;
                team.LeagueId = null;
                team.Status = TeamStatus.Rejected;
            }
        }
    }
}
