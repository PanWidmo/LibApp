using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class CreateBookDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public int NumberInStock { get; set; }
    }
}
