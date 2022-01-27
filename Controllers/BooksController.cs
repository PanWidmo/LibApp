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
    public class BooksController : Controller
    {
        [Authorize(Roles = "User, StoreManager, Owner")]
        public ViewResult Index()
        {
            return View();
        }

        [Authorize(Roles = "StoreManager, Owner")]
        public ViewResult New()
        {
            return View();
        }

        [Authorize(Roles = "User, StoreManager, Owner")]
        public ViewResult Details()
        {
            return View();
        }

        [Authorize(Roles = "StoreManager, Owner")]
        public ViewResult Edit()
        {
            return View();
        }

    }
}
