using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Repository;

namespace WebApplication14.Controllers
{
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
