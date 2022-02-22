using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibApp.Models;

namespace LibApp.ViewModels
{
    public class BookFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please provide book's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide author's name")]
        [Display(Name = "Author's name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please select Genre Type")]
        [Display(Name = "Genre type")]
        public byte? GenreId { get; set; }

        [Display(Name = "Number in stock")]
        [Required(ErrorMessage = "Please provide number in stock value")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }


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
            NumberInStock = book.NumberInStock;

        }

    }
}
