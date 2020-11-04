using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gelp.SmartHome.Common.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gelp.SmartHome.Communication.Web.Controllers {
    public class RegisterController : Controller {
        // GET: LoginController
        public ActionResult Index() {
            return View("Register");
        }


        // POST: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user) {
            try
            {
                //if login was successful
                HttpContext.Response.Cookies.Append("CookieKey", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{user.Username}, {user.Password}")));
                return RedirectToAction("Dashboard", "Dashboard");
            } catch {
                return View();
            }
        }
    }
}
