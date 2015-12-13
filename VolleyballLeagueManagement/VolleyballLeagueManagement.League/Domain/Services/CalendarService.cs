using System;
using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.Common.Extensions;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.League.Model;

namespace VolleyballLeagueManagement.League.Domain.Services
{
    /// <summary>
    /// Generate calendar using Round-robin tournament algorithm
    /// </summary>
    public class CalendarService
    {
        private Model.League league;
        private Calendar calendar;
        private bool isEvenNumberOfTeams;
        private Team[] teams;
        private Team[] groupOne;
        private Team[] groupTwo;

        public CalendarService(int leagueId)
        {
            using (var dbContext = new LeagueDataContext())
            {
                league = dbContext.Leagues.SingleOrDefault(l => l.Id == leagueId);

                if (league == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                teams = league.Teams.ToArray();
                isEvenNumberOfTeams = teams.Length.IsEvenNumber();

                SplitTeamsIntoGroups();
            }
        }

        /// <summary>
        /// Generate calendar of competitions for league given in constructor
        /// </summary>
        /// <returns></returns>
        public Calendar GenerateCompleteCalendar()
        {
            calendar = CreateCalendarEntity();
            calendar = ExecuteGenerator();

            return calendar;
        }

        private Calendar CreateCalendarEntity()
        {
            return new Calendar
            {
                League = league,
                LeagueId = league.Id,
                Rounds = new List<Round>()
            };
        }

        /// <summary>
        /// Split teams into two groups
        /// </summary>
        private void SplitTeamsIntoGroups()
        {
            SetGroupsLength(teams.Length);

            int groupOneCounter = 0;
            int groupTwoCounter = 0;

            for (int i = 0; i < teams.Length; i++)
            {
                if (i % 2 == 0)
                {
                    groupOne[groupOneCounter] = teams[i];
                    groupOneCounter++;
                }
                else
                {
                    groupTwo[groupTwoCounter] = teams[i];
                    groupTwoCounter++;
                }
            }
        }

        private void SetGroupsLength(int teamsCount)
        {
            int groupsLength = teamsCount.GetHalf();

            if (isEvenNumberOfTeams)
            {
                groupOne = new Team[groupsLength];
                groupTwo = new Team[groupsLength];
            }
            else
            {
                groupOne = new Team[groupsLength + 1];
                groupTwo = new Team[groupsLength];
            }
        }

        /// <summary>
        /// Execute calendar generator.
        /// </summary>
        /// <returns></returns>
        private Calendar ExecuteGenerator()
        {
            // Rounds count depends on teams count parity 
            // If teams count is even number, number of rounds is teams count - 1.
            // Else number of rounds is teams count
            int roundsCount = isEvenNumberOfTeams ? teams.Length : teams.Length - 1;

            for (var i = 0; i < roundsCount; i++)
            {
                // TODO complete group and game fields
                var round = new Round { Games = new List<Game>() };

                for (var j = 0; j < groupTwo.Length; j++)
                {
                    round.Games.Add(NewGame(j));
                }

                SwitchTeams();
                calendar.Rounds.Add(round);
            }
            return calendar;
        }

        private Game NewGame(int index)
        {
            return new Game { FirstTeam = groupOne[index], SecondTeam = groupTwo[index] };
        }

        /// <summary>
        /// Check teams count parity and switch teams
        /// </summary>
        private void SwitchTeams()
        {
            if (isEvenNumberOfTeams)
                SwitchTeams(1);
            else
                SwitchTeams(0);
        }

        /// <summary>
        /// Switch teams with dependence of teams count parity 
        /// </summary>
        /// <param name="startIndex"></param>
        private void SwitchTeams(int startIndex)
        {
            var tmp = groupOne[startIndex];
            var tmp2 = groupTwo[groupTwo.Length - 1];

            for (int i = startIndex; i < groupOne.Length - 1; i++)
            {
                groupOne[i] = groupOne[i + 1];
            }
            groupOne[groupOne.Length - 1] = tmp2;

            for (int i = 1; i < groupTwo.Length; i++)
            {
                groupTwo[i] = groupTwo[i - 1];
            }
            groupTwo[0] = tmp;
        }
    }
}
