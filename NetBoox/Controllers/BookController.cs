using System.Web.Mvc;
using Domain;
using NetBoox.ViewModels;
using Repository;

namespace NetBoox.Controllers
{
    public class BookController : ControllerBase
    {
        public BookController(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public ActionResult Index()
        {
            return IndexView<Book, BookViewModel>();
        }

        public ActionResult Details(int? id)
        {
            return FindView<Book, BookViewModel>(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            return CreateView<Book,BookViewModel>(bookViewModel);
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
    }
}
