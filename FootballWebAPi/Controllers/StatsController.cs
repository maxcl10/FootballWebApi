﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class StatsController : ApiController
    {
        [HttpGet]
        //[Route("api/Stats")]
        public IHttpActionResult  GetShape()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var articles = repository.GetShape();
                return Json(articles);
            }
        }

        [HttpGet]
        //[Route("api/Stats")]
        public IHttpActionResult GetRankingHistory()
        {
            using (StatsRepository repository = new StatsRepository())
            {
                var articles = repository.GetRankingHistory();
                return Json(articles);
            }
        }

        //[HttpGet]
        //public IHttpActionResult GetPlayers()
        //{
        //    using (TeamsDatabaseRepository repository = new TeamsDatabaseRepository())
        //    {
        //        var teams = repository.GetPlayers(new Guid("b8bc86da-9eea-4820-a5d5-c9f57b3b7d80")).ToList();
        //        return Json(teams);
        //    }
        //}
    }
}
