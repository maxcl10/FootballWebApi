using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public List<string> GetShape()
        {
            List<string> shapes = new List<string>();
            var games = entities.Games.Where(o => o.HomeTeamScore != null && o.AwayTeamScore != null).OrderBy(o => o.MatchDate);
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
            return entities.LazyRankings.Where(o => o.team == "Uffheim F.C.").OrderBy(o => o.uploadDate).Select(o => new
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