using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NetBoox.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(160)]
        public string Title { get; set; }
        [Required]
        [StringLength(160)]
        public string Author { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
        [DisplayName("Genre")]
        public string GenreName { get; set; }
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}