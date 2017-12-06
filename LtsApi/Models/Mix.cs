using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LtsApi.Models
{
    public class Mix
        {
            public int IdContract { get; set; }
            public string PopId { get; set; }
            public string StartDate { get; set; }
            public int StartSeq { get; set; }
            public string PartPer { get; set; }
            public string Model { get; set; }
            public string Mu { get; set; }
            public object Clinic { get; set; }
            public object AssemblyLevel { get; set; }
            public string ChassiNo { get; set; }
        } 
}


//{"idContract":41,"popId": "487777", "startDate": "Date(1497063600000)","startSeq":1,"partPer":"2017062","model":"G 400 LA4X2 E4","mu":"RU42","clinic":null,"assemblyLevel":null,"chassiNo":"3905899"}