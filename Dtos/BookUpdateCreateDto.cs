using System.ComponentModel.DataAnnotations;

namespace LibApp.Dtos
{
    public class BookUpdateCreateDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public byte GenreId { get; set; }
        public int NumberInStock { get; set; }
    }
}
