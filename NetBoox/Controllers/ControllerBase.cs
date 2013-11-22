using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using NetBoox.AutoMapper;
using Repository;

namespace NetBoox.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapperFacade MapperFacade;

        protected ControllerBase(IUnitOfWork unitOfWork, IMapperFacade mapperFacade)
        {
            UnitOfWork = unitOfWork;
            MapperFacade = mapperFacade;
        }

        protected ActionResult FindView<TModel, TViewModel>(int? id) where TModel : class
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = UnitOfWork.Repository<TModel>().FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var viewModel = MapperFacade.Map<TViewModel>(book);
            return View(viewModel);
        }

        protected ActionResult DeleteView<TModel>(int id) where TModel : class
        {
            var book = UnitOfWork.Repository<TModel>().FindById(id);
            UnitOfWork.Repository<TModel>().Delete(book);
            UnitOfWork.SaveChanges();
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult EditView<TModel, TViewModel>(TViewModel bookViewModel) where TModel : class
        {
            if (!ModelState.IsValid) return View(bookViewModel);
            var book = MapperFacade.Map<TModel>(bookViewModel);
            UnitOfWork.Repository<TModel>().Update(book);
            UnitOfWork.SaveChanges();
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult CreateView<TModel, TViewModel>(TViewModel bookViewModel) where TModel : class
        {
            if (!ModelState.IsValid) return View(bookViewModel);
            var book = MapperFacade.Map<TModel>(bookViewModel);
            UnitOfWork.Repository<TModel>().Add(book);
            UnitOfWork.SaveChanges();
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult IndexView<TModel, TViewModel>() where TModel : class
        {
            var books = UnitOfWork.Repository<TModel>().Get();
            var booksViewModel = MapperFacade.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(books);
            return View(booksViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}