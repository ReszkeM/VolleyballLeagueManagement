using System.Collections.Generic;
using System.Linq;
using VolleyballLeagueManagement.League.Contracts.ViewModels;
using VolleyballLeagueManagement.League.Model;

namespace VolleyballLeagueManagement.League.Domain.Services
{
    /// <summary>
    /// Get team games score
    /// </summary>
    public class TeamInTableService
    {
        private const int WinGame = 3;
        private readonly int teamId;
        private readonly string teamName;

        private int games = 0;
        private int winGames = 0;
        private int loseGames = 0;

        private int points = 0;

        private int winSets = 0;
        private int loseSets = 0;
        private int setsRatio = 0;

        private int winPoints = 0;
        private int losePoints = 0;
        private int pointsRatio = 0;
        
        private int winToZero = 0;
        private int winToOne = 0;
        private int winToTwo = 0;

        private int LoseToZero = 0;
        private int LoseToOne = 0;
        private int LoseToTwo = 0;


        public TeamInTableService(int teamId, string teamName)
        {
            this.teamId = teamId;
            this.teamName = teamName;
        }

        public TeamInTableViewModel GetTeamInTable()
        {
            using (var dbContext = new LeagueDataContext())
            {
                ICollection<Game> gamesAsFirstTeam = dbContext.Games.Where(g => g.FirstTeamId == teamId).ToList();
                ICollection<Game> gamesAsSecondTeam = dbContext.Games.Where(g => g.SecondTeamId == teamId).ToList();

                FindGamesResults(gamesAsFirstTeam, gamesAsSecondTeam);
                TeamInTableViewModel teamInTable = CreateTeamInTableEntity();
                return teamInTable;
            } 
        }

        private void FindGamesResults(ICollection<Game> gamesAsFirstTeam, ICollection<Game> gamesAsSecondTeam)
        {
            foreach (var game in gamesAsFirstTeam)
            {
                GetFirstTeamPoints(ref winPoints, game.Sets);
                GetSecondTeamPoints(ref losePoints, game.Sets);
                var winSetsInMatch = GetFirstTeamSets(game.Sets);
                var loseSetsInMatch = game.Sets.Count - winSetsInMatch;
                GetWinner(winSetsInMatch, loseSetsInMatch);
            }

            foreach (var game in gamesAsSecondTeam)
            {
                GetFirstTeamPoints(ref losePoints, game.Sets);
                GetSecondTeamPoints(ref winPoints, game.Sets);
                var winSetsInMatch = GetSecondTeamSets(game.Sets);
                var loseSetsInMatch = game.Sets.Count - winSetsInMatch;
                GetWinner(winSetsInMatch, loseSetsInMatch);
            }
        }

        private void GetFirstTeamPoints(ref int p, ICollection<Set> sets)
        {
            foreach (var set in sets)
            {
                Add(ref p, set.FirstTeamPoints);
            }
        }

        private void GetSecondTeamPoints(ref int p, ICollection<Set> sets)
        {
            foreach (var set in sets)
            {
                Add(ref p, set.SecondTeamPoints);
            }
        }

        private int GetFirstTeamSets(ICollection<Set> sets)
        {
            var setsBeforeMatch = winSets;

            foreach (var set in sets)
            {
                if (set.FirstTeamPoints > set.SecondTeamPoints)
                    Add(ref winSets, 1);
                else
                    Add(ref loseSets, 1);
            }
            return winSets - setsBeforeMatch;
        }

        private int GetSecondTeamSets(ICollection<Set> sets)
        {
            var setsBeforeMatch = winSets;

            foreach (var set in sets)
            {
                if (set.FirstTeamPoints < set.SecondTeamPoints)
                    Add(ref winSets, 1);
                else
                    Add(ref loseSets, 1);
            }
            return winSets - setsBeforeMatch;
        }

        private void GetWinner(int winSetsInMatch, int loseSetsInMatch)
        {
            Add(ref games, 1);

            if (winSetsInMatch == WinGame)
            {
                Add(ref winGames, 1);
                GetWinScore(loseSetsInMatch);
            }
            else
            {
                Add(ref loseGames, 1);
                GetLoseScore(winSetsInMatch);
            }
        }

        private void GetLoseScore(int winSetsInMatch)
        {
            switch (winSetsInMatch)
            {
                case 0:
                    Add(ref LoseToZero, 1);
                    Add(ref points, 0);
                    break;

                case 1:
                    Add(ref LoseToOne,  1);
                    Add(ref points, 0);
                    break;

                case 2:
                    Add(ref LoseToTwo, 1);
                    Add(ref points, 1);
                    break;
            }
        }

        private void GetWinScore(int loseSetsInMatch)
        {
            switch (loseSetsInMatch)
            {
                case 0:
                    Add(ref winToZero, 1);
                    Add(ref points, 3);
                    break;

                case 1:
                    Add(ref winToOne, 1);
                    Add(ref points, 3);
                    break;

                case 2:
                    Add(ref winToTwo, 1);
                    Add(ref points, 2);
                    break;
            }
        }

        private TeamInTableViewModel CreateTeamInTableEntity()
        {
            return new TeamInTableViewModel
            {
                Id = teamId,
                Name = teamName,
                Games = games,
                Points = points,
                WinGames = winGames,
                LoseGames = loseGames,
                WinSets = winSets,
                LoseSets = loseSets,
                SetsRatio = (double)winSets / (double)loseSets,
                WinPoints = winPoints,
                LosePoints = losePoints,
                PointsRatio = (double)winPoints / (double)losePoints,
                WinToZero = winToZero,
                WinToOne = winToOne,
                WinToTwo = winToTwo,
                LoseToZero = LoseToZero,
                LoseToOne = LoseToOne,
                LoseToTwo = LoseToTwo
            };
        }

        private void Add(ref int number, int value)
        {
            number += value;
        }
    }
}
