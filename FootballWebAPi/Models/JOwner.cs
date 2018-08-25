using FootballWebSiteApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    public class JOwner
    {
        public Guid ownerId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string facebook { get; set; }
        public string youtube { get; set; }
        public string stadium { get; set; }
        public string history { get; set; }
    }
}