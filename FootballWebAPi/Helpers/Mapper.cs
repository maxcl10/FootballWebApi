using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
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

        internal static JSponsor Map(Sponsor sponsor)
        {
            return new JSponsor
            {
                logoUrl = sponsor.logoUrl,
                orderIndex = sponsor.orderIndex,
                siteUrl = sponsor.siteUrl,
                sponsorId = sponsor.sponsorId
            };
        }

        internal static List<JStricker> Map(IQueryable<PlayerTeam> stats)
        {
            List<JStricker> jStrickers = new List<JStricker>();
            foreach (PlayerTeam stat in stats)
            {
                jStrickers.Add(Map(stat));
            }
            return jStrickers;
        }

        private static JStricker Map(PlayerTeam stat)
        {
            return new JStricker
            {
                playerName = stat.Player.firstName + " " + stat.Player.lastName,
                playerId = stat.playerId,
                championshipGoals = stat.championshipGoals,
                nationalCupGoals = stat.nationalCupGoals,
                otherCupGoals = stat.otherCupGoals,
                regionalCupGoals = stat.regionalCupGoals
            };
        }

        internal static List<JSponsor> Map(IOrderedQueryable<Sponsor> sponsors)
        {
            List<JSponsor> jSponsors = new List<JSponsor>();
            foreach (var sponsor in sponsors)
            {
                jSponsors.Add(Map(sponsor));
            }
            return jSponsors;
        }

        internal static JOwner Map(Owner owner)
        {
            return new JOwner
            {
                address = owner.address,
                city = owner.city,
                emailAddress = owner.emailAddress,
                facebook = owner.facebook,
                history = owner.history,
                name = owner.name,
                ownerId = owner.ownerId,
                phoneNumber = owner.phoneNumber,
                stadium = owner.stadium,
                youtube = owner.youtube,
                zipCode = owner.zipCode,
            };
        }

        public static JGame Map(Entities.Game game)
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

        public static IEnumerable<JArticle> Map(IEnumerable<Article> articles)
        {
            List<JArticle> jArticles = new List<JArticle>();
            foreach (Article article in articles)
            {
                jArticles.Add(Map(article));
            }
            return jArticles;
        }

        public static JArticle Map(Article article)
        {
            return new JArticle
            {
                id = article.id,
                body = article.body,
                creationDate = article.creationDate,
                deletedDate = article.deletedDate,
                draft = article.draft,
                modifiedDate = article.modifiedDate,
                publishedDate = article.publishedDate,
                publisher = article.publisher,
                title = article.title
            };
        }

        internal static IEnumerable<JPlayer> Map(IOrderedEnumerable<Player> orderedEnumerable)
        {
            List<JPlayer> jPlayers = new List<JPlayer>();
            foreach (Player player in orderedEnumerable)
            {
                jPlayers.Add(Map(player));
            }
            return jPlayers;
        }

        internal static JPlayer Map(Entities.Player player)
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