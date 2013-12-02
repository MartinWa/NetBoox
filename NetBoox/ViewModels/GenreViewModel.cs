using System.ComponentModel.DataAnnotations;
using Resources;

namespace NetBoox.ViewModels
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        [Display(Name = "Genre", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Language))]
        [StringLength(160, ErrorMessageResourceName = "FieldMaxLength160", ErrorMessageResourceType = typeof(Language))]
        public string GenreName { get; set; }
    }
}