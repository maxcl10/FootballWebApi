using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class LazyRankingRepository : IDatabaseRepository<LazyRanking>, IDisposable
    {
        FootballWebSiteDbEntities entities = new FootballWebSiteDbEntities();

        public IEnumerable<LazyRanking> Get()
        {
            return entities.LazyRankings.Where(o => o.updatedDate == null).OrderBy(o => o.position);
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
            var now = DateTime.Now;
            foreach (var lazyRanking in entities.LazyRankings.Where(o => o.updatedDate == null))
            {
                lazyRanking.updatedDate = now;
            }

            foreach (LazyRanking lazyRanking in items)
            {
                lazyRanking.rankingId = Guid.NewGuid();
                lazyRanking.uploadDate = now;
                entities.LazyRankings.Add(lazyRanking);
            }

            entities.SaveChanges();
        }


     
        public void UpdateRanking()
        {
            List<LazyRanking> items = RankingExctractor.GetRankigFromLgefUrl(Properties.Settings.Default.LafaUffheim1Url);             
            SaveRanking(items);
        }
    }
}