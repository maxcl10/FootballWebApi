using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication14.Models
{
    public interface ICrudApi<T>
    {
        IHttpActionResult Get();
        IHttpActionResult Get(string id);
        IHttpActionResult Post([FromBody]T value);
        IHttpActionResult Put(string id, [FromBody]T value);
        IHttpActionResult Delete(string id);
    }
}
