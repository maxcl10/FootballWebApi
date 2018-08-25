using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Repository
{
    public class SponsorsRepository: IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public SponsorsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JSponsor> Get()
        {
            var sponsors = Mapper.Map(entities.Sponsors.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o=>o.orderIndex));
            return sponsors;
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}