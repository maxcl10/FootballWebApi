using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class TeamsDatabaseRepository : IDatabaseRepository<JTeam>, IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public TeamsDatabaseRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public void Dispose()
        {
            entities.Dispose();
        }

        public IEnumerable<JTeam> Get()
        {
            return Mapper.Map(entities.Teams.OrderBy(o=>o.name));
        }

        public JTeam Get(string id)
        {
            return Mapper.Map( entities.Teams.Single(o => o.id.ToString() == id));
        }

        public JTeam Post(JTeam team)
        {
            throw new NotImplementedException();
            //team.id = Guid.NewGuid();

            //entities.Teams.Add(team);
            //entities.SaveChanges();

            //return team;
        }

        public JTeam Put(string id, JTeam team)
        {
            var correspondingTeam = entities.Teams.Single(o => o.id.ToString() == id);
            correspondingTeam.name = team.name;
            correspondingTeam.shortName = team.shortName;

            entities.SaveChanges();
            return team;
        }

        public void Delete(string id)
        {
            var teamToDelete = entities.Teams.Single(o => o.id.ToString() == id);
            entities.Teams.Remove(teamToDelete);
            entities.SaveChanges();
        }
    }
}