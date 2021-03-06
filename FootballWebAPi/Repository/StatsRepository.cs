﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class StatsRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public StatsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public List<JStricker> GetStrickers()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var stats = entities.PlayerTeams.Where(o => o.seasonId == currentSeasonId && o.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId && o.Team.displayOrder == 1);

            return Mapper.Map(stats);            
        }

        public List<string> GetShape()
        {
            List<string> shapes = new List<string>();
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;
            var games = entities.Games.Where(o => o.HomeTeamScore != null
            && o.AwayTeamScore != null
            && o.SeasonId == currentSeasonId).OrderBy(o => o.MatchDate);
            foreach (var game in games)
            {
                if (game.HomeTeamScore == game.AwayTeamScore) //Draw
                {
                    //penalty
                    if (game.PenaltyAwayTeamScore != null && game.PenaltyHomeTeamScore != null)
                    {
                        if (game.Team.id.ToString() == "b8bc86da-9eea-4820-a5d5-c9f57b3b7d80")
                        {
                            //home team
                            if (game.PenaltyHomeTeamScore > game.PenaltyAwayTeamScore)
                            {
                                shapes.Add("G");
                            }
                            else
                            {
                                shapes.Add("P");
                            }
                        }
                        else
                        {
                            if (game.PenaltyHomeTeamScore > game.PenaltyAwayTeamScore)
                            {
                                shapes.Add("P");
                            }
                            else
                            {
                                shapes.Add("G");
                            }
                        }
                    }
                    // prologation
                    else if (game.ProlongAwayTeamScore != null && game.ProlongHomeTeamScore != null)
                    {
                        if (game.Team.id.ToString() == "b8bc86da-9eea-4820-a5d5-c9f57b3b7d80")    //prolong uffheim home
                        {
                            if (game.ProlongHomeTeamScore > game.ProlongAwayTeamScore)
                            {
                                shapes.Add("G");
                            }
                            else
                            {
                                shapes.Add("P");
                            }
                        }
                        else
                        {
                            if (game.ProlongHomeTeamScore > game.ProlongAwayTeamScore)
                            {
                                shapes.Add("G");
                            }
                            else
                            {
                                shapes.Add("P");
                            }
                        }
                    }
                    else //no penalty no prolong
                    {
                        shapes.Add("N");
                    }
                }
                else if (game.Team.id.ToString() == "b8bc86da-9eea-4820-a5d5-c9f57b3b7d80")
                {
                    //hoem team
                    if (game.HomeTeamScore > game.AwayTeamScore)
                    {
                        shapes.Add("G");
                    }
                    else
                    {
                        shapes.Add("P");
                    }
                }
                else
                {
                    if (game.HomeTeamScore > game.AwayTeamScore)
                    {
                        shapes.Add("P");
                    }
                    else
                    {
                        shapes.Add("G");
                    }
                }
            }

            return shapes;
        }

        public object GetRankingHistory()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason);
            return entities.LazyRankings.Where(o => o.team == "Uffheim F.C." && o.uploadDate > currentSeasonId.startDate).OrderBy(o => o.uploadDate).Select(o => new
            {
                o.position,
                o.uploadDate
            }).ToList();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}