using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Resources;

namespace NetBoox.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Display(Name = "Title", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Language))]
        [StringLength(160, ErrorMessageResourceName = "FieldMaxLength160", ErrorMessageResourceType = typeof(Language))]
        public string Title { get; set; }
        [Display(Name = "Author", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Language))]
        [StringLength(160, ErrorMessageResourceName = "FieldMaxLength160", ErrorMessageResourceType = typeof(Language))]
        public string Author { get; set; }
        [Display(Name = "Rating", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Language))]
        [Range(1, 5, ErrorMessageResourceName = "Range1to5", ErrorMessageResourceType = typeof(Language))]
        public int Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Display(Name = "Genre", ResourceType = typeof(Language))]
        public string GenreName { get; set; }
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}