
using LibApp.Dtos;
using LibApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        //GET /api/books
        [HttpGet]
        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult GetAllBooks()
        {
            var result = bookService.GetAllBooks();

            return Ok(result);
        }

        //GET /api/books/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult GetBookById(int id)
        {
            var result = bookService.GetBookById(id);

            return Ok(result);
        }

        //POST /api/books
        [HttpPost]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult CreateNewBook(BookUpdateCreateDto createBookDto)
        {
            var result = bookService.CreateNewBook(createBookDto);

            return Created($"api/books/{result}", null);
        }

        //PUT /api/books
        [HttpPut("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult UpdateBook(int id, BookUpdateCreateDto updateBookDto)
        {
            bookService.UpdateBook(id, updateBookDto);

            return Ok();
        }

        //DELETE /api/books
        [HttpDelete("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult DeleteBook(int id)
        {
            bookService.DeleteBook(id);

            return Ok();
        }

    }
}
