using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class JGame
    {
        public System.Guid Id { get; set; }
        public System.Guid HomeTeamId { get; set; }
        public System.Guid AwayTeamId { get; set; }
        public System.DateTime MatchDate { get; set; }
        public System.Guid SeasonId { get; set; }
        public string Championship { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam{ get; set; }

        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
    }
}