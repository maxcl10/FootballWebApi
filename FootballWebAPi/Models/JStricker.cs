using System;

namespace FootballWebSiteApi.Models
{
    public class JStricker
    {
        public string playerName { get; set; }
        public Guid playerId { get; set; }
        public int? championshipGoals { get; set; }
        public int? nationalCupGoals { get; set; }
        public int? regionalCupGoals { get; set; }
        public int? otherCupGoals { get; set; }
    }
}