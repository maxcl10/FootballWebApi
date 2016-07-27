﻿using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class PreviousGameController : ApiController
    {
        // GET: api/Previous
        public IHttpActionResult Get()
        {
            using (GameDataBaseRepository repository = new GameDataBaseRepository())
            {
                var nextGame = repository.GetPrevious();
                return Json(nextGame);
            }
        }

    }
}
