using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LtsApi.Models
{
    public class LineEntrance
    {
        public long Id { get; set; }
        public int ContractId { get; set; }
        public int Sequence { get; set; }
        public string PopId { get; set; }
        public string Origin { get; set; }
        public string CuObj { get; set; }
        public string  StartDate { get; set; }
        public string FinishDate { get; set; }

    }
}

//"[{\"Id\":475749,\"ContractId\":41,\"Sequence\":30501,\"PopId\":\"490850\",\"Origin\":\"SYS\",\"CuObj\":\"608\",\"StartDate\":\"7/14/2017 10:25:35 AM\",\"FinishDate\":\"1/1/0001 12:00:00 AM\"}]"