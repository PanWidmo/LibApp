using Microsoft.AspNetCore.Mvc;

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
