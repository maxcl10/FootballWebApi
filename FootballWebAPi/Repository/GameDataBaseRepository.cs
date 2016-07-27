using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class GameDataBaseRepository : IDisposable, IDatabaseRepository<JGame>
    {
        private FootballWebSiteDbEntities entities;

        public GameDataBaseRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JGame> Get()
        {
            return Mapper.Map(entities.Games.OrderBy(o => o.MatchDate).Include("Team").Include("Team1"));
        }

        /// <summary>
        /// Gets the next game.
        /// </summary>
        /// <returns></returns>
        public JGame GetNext()
        {
            return Mapper.Map(entities.Games.Where(o => o.MatchDate > DateTime.Now).OrderBy(o => o.MatchDate).Include("Team").Include("Team1").First());
        }

        /// <summary>
        /// Gets the previous game.
        /// </summary>
        /// <returns></returns>
        public object GetPrevious()
        {
            var previous = entities.Games.Where(o => o.MatchDate < DateTime.Now)
                    .OrderByDescending(o => o.MatchDate)
                    .Include("Team")
                    .Include("Team1")
                    .FirstOrDefault();

            if (previous != null)
            {
                return Mapper.Map(previous);
            }

            return null;
        }

        /// <summary>
        /// Gets the specified game.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JGame Get(string id)
        {
            return Mapper.Map(entities.Games.Single(o => o.Id.ToString() == id));
        }

        /// <summary>
        /// Create a new game.
        /// </summary>
        /// <param name="jgame">The jgame.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JGame Post(JGame jgame)
        {
            var homeTeam = entities.Teams.Find(jgame.HomeTeamId);
            var awayTeam = entities.Teams.Find(jgame.AwayTeamId);

            var game = new Game
            {
                Id = Guid.NewGuid(),
                MatchDate = jgame.MatchDate,
                Championship = jgame.Championship,
                SeasonId = entities.Seasons.First().id,
                Team = homeTeam,
                Team1 = awayTeam
            };

            entities.Games.Add(game);
            entities.SaveChanges();

            return Mapper.Map(game);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="jgame">The jgame.</param>
        /// <returns></returns>
        public JGame Put(string id, JGame jgame)
        {
            var correspondingGame = entities.Games.Single(o => o.Id.ToString() == id);

            correspondingGame.Team = entities.Teams.Find(jgame.HomeTeamId);
            correspondingGame.Team1 = entities.Teams.Find(jgame.AwayTeamId);
            correspondingGame.Championship = jgame.Championship;
            correspondingGame.MatchDate = jgame.MatchDate;
            correspondingGame.HomeTeamScore = jgame.HomeTeamScore;
            correspondingGame.AwayTeamScore = jgame.AwayTeamScore;

            entities.SaveChanges();
            return jgame;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            entities.Dispose();
        }


    }
}