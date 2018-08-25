using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Repository;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class GamesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<JGame> repository = new GameRepository())
            {
                var games = repository.Get().ToList();
                return Json(games);
            }
        }

        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<JGame> repository = new GameRepository())
            {
                var games = repository.Get(id);
                return Json(games);
            }
        }

        public IHttpActionResult Post(JGame value)
        {
            using (IDatabaseRepository<JGame> repository = new GameRepository())
            {
                var game = repository.Post(value);
                return Json(game);
            }
        }

        public IHttpActionResult Put(string id, JGame value)
        {
            using (IDatabaseRepository<JGame> repository = new GameRepository())
            {
                var game = repository.Put(id, value);
                return Json(game);
            }
        }

        public IHttpActionResult Delete(string id)
        {
            using (IDatabaseRepository<JGame> repository = new GameRepository())
            {
                repository.Delete(id);
                return Ok(true);
            }
        }

    
    }
}
