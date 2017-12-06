using LtsApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LtsApi.Controllers
{
    public class FunctionsController : ApiController
    {
        [HttpGet]
        [Route("api/functions")]
        public IHttpActionResult Get()
        {
            using (LTSEntities _lts = new LTSEntities())
            {
                _lts.Configuration.ProxyCreationEnabled = false;

                var functions = (from f in _lts.TB_FUNCTION select f).ToList();

                return Ok(functions);

            }

        }
       
    }
}