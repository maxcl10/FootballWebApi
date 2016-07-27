using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class GamesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<JGame> repository = new GameDataBaseRepository())
            {
                var games = repository.Get().ToList();
                return Json(games);
            }
        }

        //public IHttpActionResult Get(string id)
        //{
        //    throw new NotImplementedException();
        //}

        public IHttpActionResult Post(JGame value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put(string id, JGame value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }



    }
}
