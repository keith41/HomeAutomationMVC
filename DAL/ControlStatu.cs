//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeAutomationMVC.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ControlStatu
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Description { get; set; }
        public Nullable<int> ControlNumber { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public string ControlGroup { get; set; }
        public string ControlType { get; set; }
    }
}
