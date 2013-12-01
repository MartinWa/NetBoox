using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Domain;
using NetBoox.AutoMapper;
using NetBoox.ViewModels;
using Repository.Abstract;

namespace NetBoox.Controllers
{
    public class GenreController : ControllerBase
    {
        public GenreController(IUnitOfWork unitOfWork, IMapperFacade mapperFacade, IDataCache dataCache) : base(unitOfWork, mapperFacade, dataCache) { }

        public ActionResult Index()
        {
            return IndexView<Genre, GenreViewModel>();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = UnitOfWork.Repository<Genre>().FindById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            var books = UnitOfWork.Repository<Book>().Get().Where(b => b.GenreId == genre.GenreId);
            var viewModel = MapperFacade.Map<Genre, GenreDetailsViewModel>(genre);
            viewModel = MapperFacade.Map(books, viewModel);
            return View(viewModel);
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
