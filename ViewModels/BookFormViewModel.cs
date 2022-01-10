using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.ViewModels
{
    public class BookFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please provide book's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide author's name")]
        [Display(Name="Author's name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please select Genre Type")]
        [Display(Name = "Genre type")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please provide release date")]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please provide number in stock value")]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            AuthorName = book.AuthorName;
            GenreId = book.GenreId;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;

        }

    }
}
