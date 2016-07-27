using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models;

namespace WebApplication14.Repository
{
    public class LazyRankingRepository : IDatabaseRepository<LazyRanking>, IDisposable
    {
        FootballWebSiteDbEntities entities = new FootballWebSiteDbEntities();

        public IEnumerable<LazyRanking> Get()
        {
            return entities.LazyRankings.OrderBy(o => o.position);
        }

        public LazyRanking Get(string id)
        {
            throw new NotImplementedException();
        }

        public LazyRanking Post(LazyRanking value)
        {
            throw new NotImplementedException();
        }

        public LazyRanking Put(string id, LazyRanking value)
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

        public void SaveRanking(List<LazyRanking> items)
        {
            foreach (var lazyRanking in entities.LazyRankings)
            {
                entities.LazyRankings.Remove(lazyRanking);
            }

            foreach (LazyRanking lazyRanking in items)
            {
                entities.LazyRankings.Add(lazyRanking);
            }

            entities.SaveChanges();
        }
    }
}