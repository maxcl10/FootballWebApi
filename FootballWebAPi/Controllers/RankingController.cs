using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using Newtonsoft.Json;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class RankingController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (LazyRankingRepository repository = new LazyRankingRepository())
            {
                return Json(repository.Get().ToList());
            }

        }


        public IHttpActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                // Read the form data.
                var files = await Request.Content.ReadAsMultipartAsync();

                // This illustrates how to get the file names.
                var fileContent = await files.Contents[0].ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<List<LazyRanking>>(fileContent);

                using (LazyRankingRepository repository = new LazyRankingRepository())
                {
                    repository.SaveRanking(items);
                }

                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public List<LazyRanking> LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<LazyRanking> items = JsonConvert.DeserializeObject<List<LazyRanking>>(json);
                return items;
            }
        }

        public IHttpActionResult Put(string id, LazyRanking value)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }


    }
}
