using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Controllers
{
    public class AccountsController : Controller
    {
        public ViewResult RegisterMainPage()
        {
            return View();
        }

        public ViewResult LoginMainPage()
        {
            return View();
        }
    }
}
