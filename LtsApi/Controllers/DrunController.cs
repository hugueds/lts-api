using LtsApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace LtsApi.Controllers
{
    public class DrunController : ApiController
    {

        [HttpGet]
        [Route("api/interferences")]
        public IHttpActionResult GetIncidents(string startDate, string endDate)
        {
            using (LTSEntities lts = new LTSEntities())
            {
                lts.DRUN.Find();
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/interferences")]
        public IHttpActionResult GetIncidentsByDays(int days)
        {
            DateTime today = DateTime.Today.Date;            
            IList<DRUN> interferences;
            using (LTSEntities lts = new LTSEntities())
            {                
                interferences = lts.DRUN.Where(x => ((int)DbFunctions.DiffDays(x.TimeStamp, DateTime.UtcNow) <=  days) ).ToList();
                foreach(var intf in interferences)
                {
                    Debug.WriteLine("Diferenca: {0}", DateTime.Now.Date.Subtract(intf.TimeStamp.Value).TotalDays );
                }
            }
            return Json(interferences);
        }       
       

        [HttpPost]
        [Route("api/interferences")]
        public IHttpActionResult CreateIncidents(IList<DRUN> itfs)
        {            
            using (LTSEntities lts = new LTSEntities())
            {
                foreach(var i in itfs)
                {
                    lts.DRUN.Add(i);
                }
                lts.SaveChanges();
            }
            return Ok();
        }      


    }




}
