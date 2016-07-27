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
    public class GamesController : ApiController, ICrudApi<Team>
    {
        public IHttpActionResult Get()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(Team value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put(string id, Team value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
