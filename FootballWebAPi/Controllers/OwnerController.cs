﻿using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballWebSiteApi.Controllers
{
    public class OwnerController : ApiController
    {
        // GET: api/Owner
        public IHttpActionResult Get()
        {
            using (OwnerRepository repository = new OwnerRepository())
            {
                var owner = repository.Get();
                return Json(owner);
            }
        }
      
    }
}
