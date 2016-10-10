using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Helpers
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

        internal static IEnumerable<JPlayer> Map(IOrderedEnumerable<Player> orderedEnumerable)
        {
            List<JPlayer> players = new List<JPlayer>();
            foreach (Player player in orderedEnumerable)
            {
                players.Add(Map(player));
            }
            return players;
        }

        internal static JPlayer Map(Player player)
        {
            return new JPlayer
            {
                id = player.id,
                position = player.position,
                dateOfBirth = player.dateOfBirth,
                firstName = player.firstName,
                height = player.height,
                lastName = player.lastName,
                nationality = player.nationality,
                previousClubs = player.previousClubs,
                weight = player.weight,
                favoriteNumber = player.favoriteNumber,
                favoritePlayer = player.favoritePlayer,
                favoriteTeam = player.favoriteTeam,
                nickname = player.nickname
            };
        }

        internal static Team Map(JTeam jteam)
        {
            return new Team
            {
                id = jteam.id,
                name = jteam.name,
                shortName = jteam.shortName,
                displayName = jteam.displayName,
                displayOrder = jteam.displayOrder
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
                shortName = team.shortName,
                displayOrder = team.displayOrder,
                displayName = team.displayName
            };
        }
    }
}