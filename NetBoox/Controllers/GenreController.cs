using System.Web.Mvc;
using Domain;
using NetBoox.ViewModels;
using Repository;

namespace NetBoox.Controllers
{
    public class GenreController : ControllerBase
    {
        public GenreController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public ActionResult Index()
        {
            return IndexView<Genre, GenreViewModel>();
        }

        public ActionResult Details(int? id)
        {
            return FindView<Genre, GenreViewModel>(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreViewModel bookViewModel)
        {
            return CreateView<Genre, GenreViewModel>(bookViewModel);
        }

        public ActionResult Edit(int? id)
        {
            return FindView<Genre, GenreViewModel>(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreViewModel bookViewModel)
        {
            return EditView<Genre, GenreViewModel>(bookViewModel);
        }

        public ActionResult Delete(int? id)
        {
            return FindView<Genre, GenreViewModel>(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return DeleteView<Genre>(id);
        }
    }
}
