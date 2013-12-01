using System.Collections.Generic;

namespace NetBoox.ViewModels
{
    public class GenreDetailsViewModel
    {
        public GenreViewModel GenreViewModel { get; set; }
        public IEnumerable<BookViewModel> BookViewModelList { get; set; }
        public BookViewModel BookViewModel { get; set; }
    }
}