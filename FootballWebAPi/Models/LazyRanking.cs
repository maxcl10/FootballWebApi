//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballWebSiteApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LazyRanking
    {
        public string team { get; set; }
        public Nullable<int> position { get; set; }
        public Nullable<int> points { get; set; }
        public Nullable<int> matchPlayed { get; set; }
        public Nullable<int> matchWon { get; set; }
        public Nullable<int> matchDraw { get; set; }
        public Nullable<int> matchLost { get; set; }
        public Nullable<int> goalsScored { get; set; }
        public Nullable<int> goalsAgainst { get; set; }
        public Nullable<int> goalDifference { get; set; }
        public Nullable<int> withdaw { get; set; }
        public Nullable<int> penality { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public System.Guid rankingId { get; set; }
        public Nullable<System.DateTime> uploadDate { get; set; }
    }
}
