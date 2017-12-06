using LtsApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LtsApi.Controllers
{
    public class CadeirinhaController : ApiController
    {
        [HttpGet]
        [Route("api/cadeirinha/{popid}")]
        public IHttpActionResult Get(string popid, bool complete = false)
        {
            using (LTSEntities  _lts = new LTSEntities())
            {
                IList<EWO_TASKROW> cadeirinhas = (from t in _lts.EWO_TASKROW
                            from e in _lts.EWO                            
                            from s in _lts.TB_STATION
                            from w in _lts.TB_WORKPLACE
                            where
                            t.IPOID == e.IPOID && t.CONTRACTID == e.CONTRACTID && s.ID == w.ID_STATION && t.CONTRACTID == w.CIMI
                            && t.TOO == "PAR"
                            && e.POPID == popid
                            && s.NAME == "112"
                            && w.NAME == "3"
                            select t).ToList();

                if (!complete)
                {
                    IEnumerable<string> cadSimple = cadeirinhas.Select(c => c.OBJ);
                    return Ok(cadSimple);
                }

                return Ok(cadeirinhas);

            }
        }
        
    }
}
