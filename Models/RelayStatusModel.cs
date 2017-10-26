using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAutomationMVC.Models
{
    public class RelayStatusModel
    {        
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string responseText { get; set; }        
    }

    public class RelayStateModel 
    {
        public string args { get; set; }
        public string args2 { get; set; }
        public string args3 { get; set; }
        public string args4 { get; set; }
        public string selectControl { get; set; }
        public bool currentState1 { get; set; }
        public bool currentState2 { get; set; }
        public bool currentState3 { get; set; }
        public bool currentState4 { get; set; }
    }
}