using NetBoox.Models;
using NetBoox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetBoox.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            IList<Genre> genres = null;
            using (var context = new BooksContext()) 
            {
                genres = context.Genres.ToList();
            }
            return View(genres);
        }

        public ActionResult Genre(int genreId)
        {
            GenreViewModel genreViewModel = new GenreViewModel();

            using (var context = new BooksContext())
            {
                genreViewModel.Genre = context.Genres.FirstOrDefault(g => g.GenreId == genreId);
                genreViewModel.Books = context.Books.Where(b => b.GenreId == genreViewModel.Genre.GenreId).ToList();
            }

            return View(genreViewModel);
        }

        public ActionResult Book(int bookId)
        {
            BookViewModel bookViewModel = new BookViewModel();

            using (var context = new BooksContext())
            {
                bookViewModel.Book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                bookViewModel.Genre = context.Genres.FirstOrDefault(g => g.GenreId == bookViewModel.Book.GenreId);
            }

            return View(bookViewModel);
        }
    }
}
