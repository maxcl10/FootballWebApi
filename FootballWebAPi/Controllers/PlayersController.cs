using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication14.Models;
using WebApplication14.Repository;

namespace WebApplication14.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class PlayersController : ApiController, ICrudApi<Player>
    {
        // GET: api/Players
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<Player> repository = new PlayerDatabaseRepository())
            {
                var players = repository.Get().ToList();
                return Json(players);
            }
        }

        // GET: api/Players/5
        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<Player> repository = new PlayerDatabaseRepository())
            {
                var player = repository.Get(id);
                return Json(player);
            }
        }

        // POST: api/Players
        public IHttpActionResult Post([FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<Player> repository = new PlayerDatabaseRepository())
                {
                    var retPlayer = repository.Post(player);
                    return Json(retPlayer);
                }
            }
            return null;
        }

        // PUT: api/Players/5
        public IHttpActionResult Put(string id, [FromBody]Player player)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<Player> repository = new PlayerDatabaseRepository())
                {

                    var retPlayer = repository.Put(id, player);
                    return Json(retPlayer);
                }
            }
            return null;
        }

        // DELETE: api/Players/5
        public IHttpActionResult Delete(string id)
        {
            using (IDatabaseRepository<Player> repository = new PlayerDatabaseRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }




    }
}
