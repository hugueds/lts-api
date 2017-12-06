using LtsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LtsApi.Controllers
{
    public class WorkplaceController : ApiController
    {
        public LTSEntities _lts { get; set; }

        [HttpGet]
        [Route("api/workplace")]
        public IHttpActionResult Get(int cimi = 0)
        {
            using (LTSEntities _lts = new LTSEntities())
            {
                _lts.Configuration.ProxyCreationEnabled = false;

                IList<TB_WORKPLACE> workplaces = (from w in _lts.TB_WORKPLACE select w).ToList();

                if (cimi != 0)
                {
                    workplaces = (from w in workplaces where w.CIMI == cimi select w).ToList();
                    if (!workplaces.Any())
                    {
                        return BadRequest();
                    }

                    return Ok(workplaces.Single());
                }

                return Ok(workplaces);
            }
            
        }
    }
}