using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        [Authorize(Roles = "User, StoreManager, Owner")]
        public ViewResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        public ViewResult New()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        public ViewResult Details()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        public ViewResult Edit()
        {

            return View();
        }

    }
}
