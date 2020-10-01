using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gelp.SmartHome.Common.Data;
using Microsoft.AspNetCore.Mvc;

namespace Gelp.SmartHome.Communication.Web.Controllers {
    public class DashboardController : Controller {
        public IActionResult Dashboard() {
            return View();
        }
    }
}
