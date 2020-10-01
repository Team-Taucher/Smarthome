using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gelp.SmartHome.Communication.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gelp.SmartHome.Communication.Web.Views.Login
{
    public class LoginScreen : PageModel
    {
        [BindProperty]
        public LoginScreenModel Login { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
