using System.Linq;
using System.Net;
using AutoMapper;
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

        public ActionResult Book(int? bookId)
        {
            if (bookId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _unitOfWork.Repository<Book>().FindById((int)bookId);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = Mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }

        [HttpPost]
        public ActionResult Book(BookViewModel newBook)
        {
            if (ModelState.IsValid)
            {
                var model = new Book
                {
                    BookName = newBook.Title,
                    Author = newBook.Author,
                    GenreId = newBook.GenreId,
                    Rating = newBook.Rating
                };
                _unitOfWork.Repository<Book>().Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("Genre", new { genreId = newBook.GenreId });
            }
            return View(newBook);
        }



        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
