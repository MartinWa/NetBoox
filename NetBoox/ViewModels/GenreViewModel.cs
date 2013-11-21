using System.ComponentModel.DataAnnotations;

namespace NetBoox.ViewModels
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}