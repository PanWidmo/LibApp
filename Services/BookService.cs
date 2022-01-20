using AutoMapper;
using LibApp.Data;
using LibApp.Exceptions;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<Book> GetAllBooks()
        {
            var books = _context.Books.Include(b => b.Genre);

            return books;
        }


        public BookDto GetBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }


        public int CreateNewBook (BookUpdateCreateDto createBookDto)
        {
            var newBook = new Book
            {
                Name = createBookDto.Name,
                AuthorName = createBookDto.AuthorName,
                GenreId = createBookDto.GenreId,
                NumberInStock = createBookDto.NumberInStock
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return newBook.Id;
        }


        public void UpdateBook(int bookId, BookUpdateCreateDto updateBookDto)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == bookId);

            if(bookInDb == null)
            {
                throw new NotFoundException("Book not found");
            }

            _mapper.Map(updateBookDto, bookInDb);
            _context.SaveChanges();

        }


        public void DeleteBook(int bookId)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == bookId);

            if (bookInDb == null)
            {
                throw new NotFoundException("Book not found");
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

        }

    }
}
