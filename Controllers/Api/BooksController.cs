using LibApp.Models;
using LibApp.Services;
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
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //GET /api/books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAllBooks();

            return Ok(result);
        }

        //GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var result = _bookService.GetBookById(id);

            return Ok(result);
        }

        //POST /api/books
        [HttpPost]
        public IActionResult CreateNewBook(BookUpdateCreateDto createBookDto)
        {
            var result = _bookService.CreateNewBook(createBookDto);

            return Created($"api/books/{result}", null);
        }

        //PUT /api/books
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookUpdateCreateDto updateBookDto)
        {
            _bookService.UpdateBook(id, updateBookDto);

            return Ok();
        }

        //DELETE /api/books
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);

            return Ok();
        }

        private readonly IBookService _bookService;
    }
}
