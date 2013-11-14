using System.Collections.Generic;
using Domain;

namespace NetBoox.ViewModels
{
    public class GenreViewModel
    {
        public Genre Genre { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}