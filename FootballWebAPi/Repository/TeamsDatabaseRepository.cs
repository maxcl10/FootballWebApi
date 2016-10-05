﻿using System;
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

        public IEnumerable<JTeam> GetHomeTeams()
        {
            return Mapper.Map(entities.Teams.Where(o=>o.homeTeam.HasValue && o.homeTeam.Value).OrderBy(o => o.name));
        }

        public IEnumerable<JPlayer> GetPlayers(Guid id)
        {
            List<JPlayer> players = new List<JPlayer>();
            var playersId = entities.PlayerTeams.Where(o => o.teamId == id);
            foreach (PlayerTeam playerTeam in playersId)
            {
                players.Add(Mapper.Map(playerTeam.Player));
            }

            return players;
        }

        public JTeam Get(string id)
        {
            return Mapper.Map( entities.Teams.Single(o => o.id.ToString() == id));
        }

        public JTeam Post(JTeam jteam)
        {
            jteam.id = Guid.NewGuid();
            Team team = Mapper.Map(jteam);

            entities.Teams.Add(team);
            entities.SaveChanges();

            return jteam;
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


        public void AddPlayer(string playerId, string teamId)
        {
            PlayerTeam playerTeam = new PlayerTeam
            {
                playerId = new Guid(playerId),
                teamId = new Guid(teamId),
                playerTeamId = Guid.NewGuid(),
                seasonId = entities.Seasons.First().id
            };

            entities.PlayerTeams.Add(playerTeam);
            entities.SaveChanges();
        }

        public void RemovePlayer(string playerId, string teamId)
        {
            var entity = entities.PlayerTeams.SingleOrDefault(o => o.playerId == new Guid(playerId) && o.teamId == new Guid(teamId));
            entities?.PlayerTeams.Remove(entity);
            entities.SaveChanges();
        }
    }
}