using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels; 

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Random()
        {
            var firstBook = new Book() { Name = "Engish dict" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Jan Dzban"},
                new Customer {Name = "Tomasz Baran"},
            };

            var viewModel = new RandomBookViewModel
            {
                Book = firstBook,
                Customers = customers,
            };

            return View(viewModel);
        }

        public IActionResult Edit (int bookId)
        {
            return Content("id= " + bookId);
        }

        public IActionResult Index()
        {
            var books = GetBooks();

            return View(books);
        }

        [Route("books/released/{year:regex(^\\d{{4}}$):min(1925):max(2021)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Id = 1, Name="Hamlet"},
                new Book {Id = 2, Name="Ulysses"},
            };
        }


    }
}
