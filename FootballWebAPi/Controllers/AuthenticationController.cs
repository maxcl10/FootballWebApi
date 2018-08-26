using FootballWebSiteApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballWebSiteApi.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [Route("api/authentication/{alias}/{password}")]
        public IHttpActionResult UserAllowed(string alias, string password)
        {
            using (AuthenticationRepository repository = new AuthenticationRepository())
            {
                var isAuthorized = repository.IsAuthorized(alias, password);
                return Json(isAuthorized);
            }
        }
    }
}
