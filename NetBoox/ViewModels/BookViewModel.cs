using System.ComponentModel.DataAnnotations;

namespace NetBoox.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}