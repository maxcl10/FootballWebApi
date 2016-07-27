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
    public class TeamsController : ApiController, ICrudApi<JTeam>
    {


        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsDatabaseRepository())
            {
                var teams = repository.Get().ToList();
                return Json(teams);
            }
        }

        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsDatabaseRepository())
            {
                var team = repository.Get(id);
                return Json(team);
            }
        }

        public IHttpActionResult Post([FromBody] JTeam team)
        {
            throw new NotImplementedException();
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JTeam> repository = new TeamsDatabaseRepository())
                {
                    var retTeam = repository.Post(team);
                    return Json(retTeam);
                }
            }
            return null;
        }

        public IHttpActionResult Put(string id, [FromBody] JTeam team)
        {
            throw  new NotImplementedException();
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JTeam> repository = new TeamsDatabaseRepository())
                {

                    var retTeam = repository.Put(id, team);
                    return Json(retTeam);
                }
            }
            return null;
        }

        public IHttpActionResult Delete(string id)
        {
            using (IDatabaseRepository<JTeam> repository = new TeamsDatabaseRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }}
}
