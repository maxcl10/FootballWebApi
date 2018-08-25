using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballWebSiteApi.Controllers
{
    public class SponsorsController : ApiController
    {
        // GET: api/Sponsors
        public IHttpActionResult Get()
        {
            using (SponsorsRepository repository = new SponsorsRepository())
            {
                var sponsors = repository.Get();
                return Json(sponsors);
            }
        }

        // GET: api/Sponsors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sponsors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sponsors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sponsors/5
        public void Delete(int id)
        {
        }
    }
}
