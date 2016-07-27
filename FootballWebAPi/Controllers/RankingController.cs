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
using Newtonsoft.Json;
using WebApplication14.Models;
using WebApplication14.Repository;

namespace WebApplication14.Controllers
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

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);

                    var items = LoadJson(file.LocalFileName);

                    using (LazyRankingRepository repository = new LazyRankingRepository())
                    {
                        repository.SaveRanking(items);
                    }
                }



                return Json(true);
            }
            catch (System.Exception e)
            {
                return Json(e);
            }

            return Json(true);

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
