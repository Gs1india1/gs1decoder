using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GS1Decode;

namespace WebApplication1.Controllers
{
    public class IdentifiersController : ApiController
    {
        // GET: api/AIList
        public IEnumerable<object> Get()
        {
            yield return AI.AIMaster;
        }

        // GET: api/AIList/5
        public IEnumerable<object> Get(string code)
        {
            AI ai;
            if (AI.AIMaster.TryGetValue(code, out ai))
            {
                yield return ai;
            }
          
        }

        // POST: api/AIList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AIList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AIList/5
        public void Delete(int id)
        {
        }
    }
}
