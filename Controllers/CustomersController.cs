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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .Include(c => c.RoleType)
                .SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var roleTypes = _context.RoleTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                RoleTypes = roleTypes
            };
            return View("CustomerForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                RoleTypes = _context.RoleTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    RoleTypes = _context.RoleTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
                customerInDb.PasswordHash = customer.PasswordHash;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
                customerInDb.RoleTypeId = customer.RoleTypeId;
            }

            try
            {
                _context.SaveChanges();
            }

            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Customers");
        }


    }
}
