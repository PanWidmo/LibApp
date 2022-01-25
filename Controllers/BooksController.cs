using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult New()
        {
            return View();
        }

        public ViewResult Details()
        {
            return View();
        }

        public ViewResult Edit()
        {
            return View();
        }

    }
}
