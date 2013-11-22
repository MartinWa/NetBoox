using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetBoox.ViewModels
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        [Required]
        [DisplayName("Genre")]
        [StringLength(160)]
        public string GenreName { get; set; }
    }
}