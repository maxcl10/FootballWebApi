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

        public IEnumerable<JGame> Get()
        {
            return Mapper.Map(entities.Games.OrderBy(o => o.MatchDate).Include("Team").Include("Team1"));
        }

        public JGame GetNext()
        {
            return Mapper.Map(entities.Games.Where(o => o.MatchDate > DateTime.Now).OrderBy(o => o.MatchDate).Include("Team").Include("Team1").First());
        }

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

        public JGame Get(string id)
        {
            throw new NotImplementedException();
        }

        public JGame Post(JGame value)
        {
            throw new NotImplementedException();
        }

        public JGame Put(string id, JGame value)
        {
            throw new NotImplementedException();
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