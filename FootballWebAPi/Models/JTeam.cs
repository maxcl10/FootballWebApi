﻿using System;

namespace FootballWebSiteApi.Models
{
    public class JTeam
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string displayName { get; set; }
        public int? displayOrder { get; set; }
    }
}