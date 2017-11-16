using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HomeAutomationMVC.Models;

namespace HomeAutomationMVC.ViewModels
{
    public class GPIOViewModel
    {
        public IEnumerable<RelayStateModel> gpioCollection { get; set; }
    }
}