using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LtsApi.Models
{

    public class Parameter
    {
        public int Id { get; set; }
        public int Contractid { get; set; }
        public int Ipoid { get; set; }
        public string Wplobj { get; set; }
        public string Taskobj { get; set; }
        public string Too { get; set; }
        public string Obj { get; set; }
        public string Sname { get; set; }
        public float Quantity { get; set; }
        public string Ccposno { get; set; }
        public string Ciidno { get; set; }
        public string Conid { get; set; }
        public int Posno { get; set; }
        public string Lname { get; set; }
        public int Linenum { get; set; }
    }

}