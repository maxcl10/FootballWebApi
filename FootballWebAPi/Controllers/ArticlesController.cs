using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using WebApplication14.Models;
using WebApplication14.Repository;

namespace WebApplication14.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    
    public class ArticlesController : ApiController, ICrudApi<Article>
    {
        // GET: api/Articles
        public IHttpActionResult Get()
        {
            using (IDatabaseRepository<Article> repository = new ArticleDatabaseRepository())
            {
                var articles = repository.Get().ToList();
                return Json(articles);
            }

        }

        // GET: api/Articles/5
        public IHttpActionResult Get(string id)
        {
            using (IDatabaseRepository<Article> repository = new ArticleDatabaseRepository())
            {
                var article = repository.Get(id);
                return Json(article);
            }
        }

        // POST: api/Articles
        public IHttpActionResult Post([FromBody]Article article)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<Article> repository = new ArticleDatabaseRepository())
                {
                    var retArticle = repository.Post(article);
                    return Json(retArticle);
                }
            }
            return null;
        }


        // PUT: api/Articles/5
        public IHttpActionResult Put(string id, [FromBody]Article article)
        {
            if (ModelState.IsValid)
            {
                using (IDatabaseRepository<Article> repository = new ArticleDatabaseRepository())
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
            using (IDatabaseRepository<Article> repository = new ArticleDatabaseRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }
    }
}
