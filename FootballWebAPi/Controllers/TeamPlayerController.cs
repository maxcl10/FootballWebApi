﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class TeamPlayerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPlayers(string id)
        {
            using (TeamsDatabaseRepository repository = new TeamsDatabaseRepository())
            {
                var teams = repository.GetPlayers(new Guid(id)).ToList();
                return Json(teams);
            }
        }

    }
}