using System.Linq;
using DataAccess;
using Domain;
using NetBoox.ViewModels;
using System.Web.Mvc;
using Repository;

namespace NetBoox.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Genre> _genreRepository;

        // TODO MW Use Ninject for this and remove this constructor
        public BookController()
        {
            var context = new BooksContext();
            _bookRepository = new Repository<Book>(context);
            _genreRepository = new Repository<Genre>(context);
        }

        public BookController(IRepository<Book> bookRepositoryrepository, IRepository<Genre> genreRepository)
        {
            _bookRepository = bookRepositoryrepository;
            _genreRepository = genreRepository;
        }

        public ActionResult Index()
        {
            return View(_genreRepository.Get());
        }

        public ActionResult Genre(int genreId)
        {
            var genreViewModel = new GenreViewModel
            {
                Genre = _genreRepository.Get().FirstOrDefault(g => g.GenreId == genreId),
                Books = _bookRepository.Get().Where(b => b.GenreId == genreId)
            };
            return View(genreViewModel);
        }

        public ActionResult Book(int bookId)
        {
            var bookViewModel = new BookViewModel { Book = _bookRepository.Get().FirstOrDefault(b => b.BookId == bookId) };
            bookViewModel.Genre = _genreRepository.Get().FirstOrDefault(g => g.GenreId == bookViewModel.Book.GenreId);
            return View(bookViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _bookRepository.Dispose();
            _genreRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
