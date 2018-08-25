using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using JPlayer = FootballWebSiteApi.Models.JPlayer;

namespace FootballWebSiteApi.Repository
{
    public class PlayerRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public PlayerRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<JPlayer> Get(bool current = false)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;
            if (current)
            {
                return Mapper.Map(entities.Players.Where(o => o.PlayerTeams.Any(s => s.seasonId == currentSeasonId)).ToList().OrderBy(p => GetOrder(p.position)));
            }
            else
            {
                return Mapper.Map(entities.Players.ToList().OrderBy(p => GetOrder(p.position)));
            }
        }

        private int GetOrder(string position)
        {
            switch (position)
            {
                case "Gardien":
                    return 0;
                case "Defenseur":
                    return 1;
                case "Milieu":
                    return 2;
                case "Attaquant":
                    return 3;
                default:
                    return 4;
            }
        }

        public JPlayer Get(string id)
        {
            return Mapper.Map(entities.Players.Single(o => o.id.ToString() == id));
        }


        public Entities.Player Post(Entities.Player player)
        {
            player.id = Guid.NewGuid();


            entities.Players.Add(player);
            entities.SaveChanges();
            return player;
        }

        public Entities.Player Put(string id, Entities.Player player)
        {
            var correspondingPlayer = entities.Players.Single(o => o.id.ToString() == id);

            correspondingPlayer.firstName = player.firstName;
            correspondingPlayer.lastName = player.lastName;
            correspondingPlayer.dateOfBirth = player.dateOfBirth;
            correspondingPlayer.height = player.height;
            correspondingPlayer.weight = player.weight;
            correspondingPlayer.nationality = player.nationality;
            correspondingPlayer.position = player.position;
            correspondingPlayer.previousClubs = player.previousClubs;
            correspondingPlayer.favoriteNumber = player.favoriteNumber;
            correspondingPlayer.nickname = player.nickname;
            correspondingPlayer.favoritePlayer = player.favoritePlayer;
            correspondingPlayer.favoriteTeam = player.favoriteTeam;

            entities.SaveChanges();
            return player;
        }

        public void Delete(string id)
        {
            var playerToDelete = entities.Players.Single(o => o.id.ToString() == id);
            entities.Players.Remove(playerToDelete);
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }


    }
}