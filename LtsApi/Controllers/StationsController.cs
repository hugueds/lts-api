using LtsApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LtsApi.Controllers
{
    public class StationsController : ApiController
    {
        [HttpGet]
        [Route("api/stations")]
        public IHttpActionResult Get()
        {

            using (LTSEntities _lts = new LTSEntities())
            {
                var stations = (from s in _lts.TB_STATION
                                from f in _lts.TB_FUNCTION
                                where s.ID_FUNCTION == f.ID
                                select new
                                {
                                    FUNCTION = f.NAME, s.ID,  s.NAME  ,s.POSITION, s.DESCRIPTION
                                 }).ToList();

                return Ok(stations);
            }

                
        }

        [HttpGet]
        [Route("api/stations/{station}")]
        public IHttpActionResult GetStation(string station)
        {
            using (LTSEntities _lts = new LTSEntities())
            {
                try
                {
                    var stn = (from s in _lts.TB_STATION
                               from f in _lts.TB_FUNCTION
                               where s.ID_FUNCTION == f.ID && s.NAME == station
                               select new
                               {
                                   FUNCTION = f.NAME,
                                   s.ID,
                                   s.NAME,
                                   s.POSITION,
                                   s.DESCRIPTION
                               }).ToList().Single();

                    return Ok(stn);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                    return NotFound();
                }
            }

            
        }


    }
}