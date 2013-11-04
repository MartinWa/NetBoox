using NetBoox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetBoox.ViewModels
{
    public class GenreViewModel
    {
        public Genre Genre { get; set; }
        public IList<Book> Books { get; set; }
    }
}