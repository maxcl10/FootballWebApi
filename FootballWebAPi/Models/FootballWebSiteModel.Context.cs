﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FootballWebSiteDbEntities : DbContext
    {
        public FootballWebSiteDbEntities()
            : base("name=FootballWebSiteDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Championship> Championships { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<LazyRanking> LazyRankings { get; set; }
    }
}
