using System.Threading;
using System.Web.Mvc;
using Domain;
using NetBoox.AutoMapper;
using NetBoox.ViewModels;
using Repository.Abstract;

namespace NetBoox.Controllers
{
    public class BookController : ControllerBase
    {
        public BookController(IUnitOfWork unitOfWork, IMapperFacade mapperFacade, IDataCache dataCache) : base(unitOfWork, mapperFacade, dataCache) { }

        public ActionResult Index()
        {
            return IndexViewCached<Book, BookViewModel>();
        }

        public ActionResult Details(int? id)
        {
            return FindView<Book, BookViewModel>(id);
        }

        public ActionResult Create()
        {
            var viewModel = MapperFacade.Map<BookViewModel>(new Book());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            return CreateView<Book, BookViewModel>(bookViewModel);
        }

        public ActionResult Edit(int? id)
        {
            return FindView<Book, BookViewModel>(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            return EditView<Book, BookViewModel>(bookViewModel);
        }

        public ActionResult Delete(int? id)
        {
            return FindView<Book, BookViewModel>(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return DeleteView<Book>(id);
        }

        public ActionResult AddBook(BookViewModel bookViewModel)
        {
            var book = MapperFacade.Map<Book>(bookViewModel);
            if (!ModelState.IsValid)
            {
                var viewModel = MapperFacade.Map<BookViewModel>(book);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("AddBookForm", bookViewModel);
                }
                return View("Create", viewModel);
            }
            UnitOfWork.Repository<Book>().Add(book);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Details", "Genre", new { Id = bookViewModel.GenreId });
        }
    }
}
