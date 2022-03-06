using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        /*[Authorize(Roles = "User, StoreManager, Owner")]*/
        public ViewResult Index()
        {
            return View();
        }

        /*[Authorize(Roles = "StoreManager, Owner")]*/
        public ViewResult New()
        {
            return View();
        }

        /*[Authorize(Roles = "User, StoreManager, Owner")]*/
        public ViewResult Details()
        {
            return View();
        }

        /*[Authorize(Roles = "StoreManager, Owner")]*/
        public ViewResult Edit()
        {
            return View();
        }

    }
}
