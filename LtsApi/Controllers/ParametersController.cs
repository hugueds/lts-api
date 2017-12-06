using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LtsApi.Models;
using System.Web;
using System.Diagnostics;
using System.Collections;

namespace LtsApi.Controllers
{
    public class ParametersController : ApiController
    {
        public LTSEntities _lts { get; set; }

        public string Get()
        {
            return "Please, provide a valid Popid";
        }

        [HttpGet]
        [Route("api/parametros/{popid}")]
        public IHttpActionResult Get(string popid, string station, string position)
        {           
            using ( _lts = new LTSEntities())
            {
                IList parameters = (from t in _lts.EWO_TASKROW
                                    from e in _lts.EWO                                    
                                    from s in _lts.TB_STATION
                                    from w in _lts.TB_WORKPLACE
                                    where
                                    t.IPOID == e.IPOID && t.CONTRACTID == e.CONTRACTID && s.ID == w.ID_STATION && t.CONTRACTID == w.CIMI
                                    //&& t.Too == "LT"
                                    && e.POPID == popid
                                    && s.NAME == station
                                    && w.NAME == position
                                    select t).ToList();

                return Ok(parameters);
            }            

        }
    }
}

