using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.League.Contracts.ViewModels;
using VolleyballLeagueManagement.League.Domain.Handlers;
using VolleyballLeagueManagement.League.Model;

namespace VolleyballLeagueManagement.League.Domain.Services
{
    /// <summary>
    /// Place teams in table by rules order defined in league regulations
    /// </summary>
    public class LeagueTableService
    {
        private Model.League league;
        private ICollection<Team> teams;
        private ICollection<OrderRules> tableOrderRules; 

        public LeagueTableService(int leagueId)
        {
            using (var dbContext = new LeagueDataContext())
            {
                league = dbContext.Leagues.SingleOrDefault(l => l.Id == leagueId);

                if (league == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                teams = league.Teams;
                tableOrderRules = new List<OrderRules>
                {
                    league.Regulations.TableOrderRules.FifthRule,
                    league.Regulations.TableOrderRules.FourthRule,
                    league.Regulations.TableOrderRules.ThirdRule,
                    league.Regulations.TableOrderRules.SecondRule,
                    league.Regulations.TableOrderRules.FirstRule,
                };
            }
        }

        /// <summary>
        /// Place teams in table for league given in constructor
        /// </summary>
        /// <returns></returns>
        public ICollection<TeamInTableViewModel> ExecuteTableOrderRules()
        {
            ICollection<TeamInTableViewModel> teamsStats = GetTeamsStats();
            ExecuteOrderRules(teamsStats);
            return teamsStats;
        }

        /// <summary>
        /// Create TeamInTableService instance and get teams stats
        /// </summary>
        /// <returns></returns>
        private ICollection<TeamInTableViewModel> GetTeamsStats()
        {
            var teamsInTable = new List<TeamInTableViewModel>();

            foreach (var team in teams)
            {
                var service = new TeamInTableService(team.Id, team.Name);
                teamsInTable.Add(service.GetTeamInTable());
            }

            return teamsInTable;
        }

        /// <summary>
        /// Execute order rules from less importatn to the most important rule.
        /// Using Chain of Responsibility design pattern
        /// </summary>
        /// <param name="teamsStats"></param>
        private void ExecuteOrderRules(ICollection<TeamInTableViewModel> teamsStats)
        {
            OrderRuleHandler h1 = new DirectMatchRuleHandler();
            OrderRuleHandler h2 = new PointsRuleHandler();
            OrderRuleHandler h3 = new SetsRatioRuleHandler();
            OrderRuleHandler h4 = new SmallPointsRuleHandler();
            OrderRuleHandler h5 = new WinGamesRuleHandler();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            h3.SetSuccessor(h4);
            h4.SetSuccessor(h5);

            foreach (var orderRule in tableOrderRules)
            {
                h1.Handle(orderRule, ref teamsStats);
            }
        }
    }
}
