﻿using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET /api/books
        [HttpGet]
        [Authorize]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                                    .Include(c => c.Genre)
                                    .ToList()
                                    .Select(_mapper.Map<Book, BookDto>);

            return Ok(books);
        }

        //GET /api/books/{id}
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        //POST /api/books
        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;

            return CreatedAtRoute(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }

        //PUT /api/books
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == bookDto.Id);

            if(bookInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/books
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }

        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
    }
}
