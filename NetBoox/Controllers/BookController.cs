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
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Genre>().Get());
        }

        public ActionResult Genre(int genreId)
        {
            var genreViewModel = new GenreViewModel
            {
                Genre = _unitOfWork.Repository<Genre>().Get().FirstOrDefault(g => g.GenreId == genreId),
                Books = _unitOfWork.Repository<Book>().Get().Where(b => b.GenreId == genreId)
            };
            return View(genreViewModel);
        }

        public ActionResult Book(int bookId)
        {
            var bookViewModel = new BookViewModel { Book = _unitOfWork.Repository<Book>().Get().FirstOrDefault(b => b.BookId == bookId) };
            bookViewModel.Genre = _unitOfWork.Repository<Genre>().Get().FirstOrDefault(g => g.GenreId == bookViewModel.Book.GenreId);
            return View(bookViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
