﻿using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class NextGameController : ApiController
    {
        // GET: api/NextGame
        public IHttpActionResult Get()
        {
            using (GameDataBaseRepository repository = new GameDataBaseRepository())
            {
                var nextGame = repository.GetNext();
                return Json(nextGame);
            }
        }
    }
}
