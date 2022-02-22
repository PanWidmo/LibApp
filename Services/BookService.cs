using AutoMapper;
using LibApp.Data;
using LibApp.Exceptions;
using LibApp.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LibApp.Models;

namespace LibApp.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        BookDto GetBookById(int bookId);
        int CreateNewBook(BookUpdateCreateDto createBookDto);
        void UpdateBook(int bookId, BookUpdateCreateDto updateBookDto);
        void DeleteBook(int bookId);
    }

    public class BookService : IBookService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public IEnumerable<Book> GetAllBooks()
        {
            var books = context.Books.Include(b => b.Genre);

            return books;
        }


        public BookDto GetBookById(int bookId)
        {
            var book = context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }


        public int CreateNewBook(BookUpdateCreateDto createBookDto)
        {
            var newBook = new Book
            {
                Name = createBookDto.Name,
                AuthorName = createBookDto.AuthorName,
                GenreId = createBookDto.GenreId,
                NumberInStock = createBookDto.NumberInStock
            };

            context.Books.Add(newBook);
            context.SaveChanges();

            return newBook.Id;
        }


        public void UpdateBook(int bookId, BookUpdateCreateDto updateBookDto)
        {
            var bookInDb = context.Books.SingleOrDefault(b => b.Id == bookId);

            if(bookInDb == null)
            {
                throw new NotFoundException("Book not found");
            }

            mapper.Map(updateBookDto, bookInDb);
            context.SaveChanges();

        }


        public void DeleteBook(int bookId)
        {
            var bookInDb = context.Books.SingleOrDefault(b => b.Id == bookId);

            if (bookInDb == null)
            {
                throw new NotFoundException("Book not found");
            }

            context.Books.Remove(bookInDb);
            context.SaveChanges();

        }

    }
}
