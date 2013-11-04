using NetBoox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetBoox.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}