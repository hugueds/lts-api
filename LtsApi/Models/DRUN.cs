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
    
    public partial class DRUN
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public string StationDescription { get; set; }
        public string CellDescription { get; set; }
        public Nullable<int> StationPosition { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public Nullable<bool> isStopTime { get; set; }
        public Nullable<bool> isProcessStopTime { get; set; }
        public string Popid { get; set; }
        public string TimeAmount { get; set; }
        public string AndonMessage { get; set; }
    }
}
