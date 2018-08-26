using FootballWebSiteApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FootballWebSiteApi.Repository
{
    public class AuthenticationRepository:IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public AuthenticationRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public bool IsAuthorized(string alias, string password)
        {
            return entities.Users.Where(o => o.alias == alias && o.password == password && o.ownerId.ToString() == Properties.Settings.Default.OwnerId).Any();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}