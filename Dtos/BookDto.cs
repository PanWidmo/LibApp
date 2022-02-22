using LibApp.Dtos;

namespace LibApp.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public GenreDto Genre { get; set; }
        public byte GenreId { get; set; }
        public int NumberInStock { get; set; }
    }
}
