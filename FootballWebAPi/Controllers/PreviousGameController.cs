using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication14.Repository;

namespace WebApplication14.Controllers
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
