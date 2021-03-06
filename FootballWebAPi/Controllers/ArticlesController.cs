﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    
    public class ArticlesController : ApiController, ICrudApi<JArticle>
    {
        // GET: api/Articles
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
            {
                var articles = repository.Get().Take(20).ToList();
                return Json(articles);
            }

        }

        // GET: api/Articles/5
        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
            {
                var article = repository.Get(id);
                return Json(article);
            }
        }

        // POST: api/Articles
        public IHttpActionResult Post([FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
                {
                    var retArticle = repository.Post(article);
                    return Json(retArticle);
                }
            }
            return null;
        }


        // PUT: api/Articles/5
        public IHttpActionResult Put(string id, [FromBody]JArticle article)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
                {

                    var retArticle = repository.Put(id, article);
                    return Json(retArticle);
                }
            }
            return null;
        }

        // DELETE: api/Articles/5
        public IHttpActionResult Delete(string id)
        {
            using (IDatabaseRepository<JArticle> repository = new ArticleRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }
    }
}
