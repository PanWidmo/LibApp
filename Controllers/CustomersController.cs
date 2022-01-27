using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
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
