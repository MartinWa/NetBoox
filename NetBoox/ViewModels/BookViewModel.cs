using System.ComponentModel.DataAnnotations;

namespace NetBoox.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}