﻿using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class PlayerDatabaseRepository : IDatabaseRepository<Player>
    {
        private FootballWebSiteDbEntities entities;

        public PlayerDatabaseRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<Player> Get()
        {
            return entities.Players.ToList().OrderBy(o => GetOrder(o.position));
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

        public Player Get(string id)
        {
            return entities.Players.Single(o => o.id.ToString() == id);
        }


        public Player Post(Player player)
        {
            player.id = Guid.NewGuid();



            entities.Players.Add(player);
            entities.SaveChanges();
            return player;

        }

        public Player Put(string id, Player player)
        {
            var correspondingPlayer = entities.Players.Single(o => o.id.ToString() == id);

            correspondingPlayer.firstName = player.firstName;
            correspondingPlayer.lastName = player.lastName;
            correspondingPlayer.dateOfBirth = player.dateOfBirth;
            correspondingPlayer.height = player.height;
            correspondingPlayer.weight = player.weight;
            correspondingPlayer.nationality = player.nationality;
            correspondingPlayer.position = player.position;


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