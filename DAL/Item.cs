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
    
    public partial class Item
    {
        public int id { get; set; }
        public string ItemName { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> ItemQuantity { get; set; }
        public string ItemSize { get; set; }
        public string ItemComments { get; set; }
        public string ItemCategory { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
