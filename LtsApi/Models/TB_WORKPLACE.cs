//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LtsApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_WORKPLACE
    {
        public int ID { get; set; }
        public int ID_STATION { get; set; }
        public int POSITION { get; set; }
        public string NAME { get; set; }
        public Nullable<int> CIMI { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual TB_STATION TB_STATION { get; set; }
    }
}
