using GS1Decode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class DecoderController : ApiController
    {
        // GET api/values
        public void Get()
        {
        }

        // GET api/values/5
        public IEnumerable<object> Get(string code)
        {
            GS1DecodeEngine data = new GS1DecodeEngine(code);
            yield return data.Data;
        }

        

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
