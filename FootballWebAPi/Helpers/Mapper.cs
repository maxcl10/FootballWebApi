using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using WebApplication14.Models;

namespace WebApplication14.Helpers
{
    public static class Mapper
    {
        public static IEnumerable<JGame> Map(IEnumerable<Game> games)
        {
            List<JGame> Jgames = new List<JGame>();
            foreach (Game game in games)
            {
                Jgames.Add(Map(game));
            }
            return Jgames;
        }

        public static JGame Map(Game game)
        {
            return new JGame
            {
                Id = game.Id,
                AwayTeamId = game.AwayTeam,
                AwayTeam = game.Team1.name,
                HomeTeamId = game.HomeTeam,
                HomeTeam = game.Team.name,
                Championship = game.Championship,
                MatchDate = game.MatchDate,
                SeasonId = game.SeasonId,
                AwayTeamScore = game.AwayTeamScore,
                HomeTeamScore = game.HomeTeamScore
            };
        }

        public static IEnumerable<JTeam> Map(IEnumerable<Team> teams)
        {
            List<JTeam> JTeams = new List<JTeam>();
            foreach (var team in teams)
            {
                JTeams.Add(Map(team));
            }
            return JTeams;
        }

        public static JTeam Map(Team team)
        {
            return new JTeam
            {
                id = team.id,
                name = team.name,
                shortName = team.shortName
            };
        }
    }
}