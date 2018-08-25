using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    
        public class JArticle
        {
            public Guid id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
            public string publisher { get; set; }
            public DateTime? publishedDate { get; set; }
            public DateTime? modifiedDate { get; set; }
            public DateTime? deletedDate { get; set; }
            public DateTime creationDate { get; set; }
            public bool? draft { get; set; }           
        }
    
}