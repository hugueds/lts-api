using LtsApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LtsApi.Controllers
{
    public class MixController : ApiController
    {        
        public readonly MixService.IMixService _mix;        

        private string _format = "yyyyMMdd";

        [HttpGet]
        [Route("api/mix/complete")]
        public IHttpActionResult GetComplete()
        {
            long line = 41;
            using (var _mix = new MixService.MixServiceClient())
            {
                IList<Mix> popids = JsonConvert.DeserializeObject<List<Mix>>(_mix.GetListPlannedMix(line, DateTime.Now.Date, 0, 100));
                return Ok(popids);
            }

        }

        [HttpGet]
        [Route("api/mix/entrance")]
        public IHttpActionResult GetEntrance(bool complete = false, string line = "truck", int quantity = 1)
        {
            int contractId = (line == "truck") ? 181 : 141;

            using (MixService.MixServiceClient _mix = new MixService.MixServiceClient())
            {
                IList<LineEntrance> popids = JsonConvert.DeserializeObject<List<LineEntrance>>(_mix.GetListByContractAsync(contractId, quantity, "ServiceLTS").Result);
                if (complete)
                {
                   return Ok(popids);
                }

                IEnumerable<string> popidSimple = from p in popids select p.PopId;
                return Ok(popidSimple);                
            }
        }                  

        [HttpGet]
        [Route("api/mix/simple")]
        public IHttpActionResult GetSimple(string date = null)
        {
            DateTime newDate;
            if (date != null)
            {                
                bool result = DateTime.TryParseExact(date, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate);
                Debug.WriteLine(newDate);
            }
            else
            {
                newDate = DateTime.Now.Date;
            }

            using (MixService.MixServiceClient _mix = new MixService.MixServiceClient())
            {
                IList<Mix> mixList = JsonConvert.DeserializeObject<List<Mix>>(_mix.GetListPlannedMix(41, newDate, 0, 100));

                IEnumerable<string> popids = from m in mixList select m.PopId;
                
                return Ok(popids);
            }

        }

    }
}
