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
            var data = UnitOfWork.Repository<TModel>().FindById(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = MapperFacade.Map<TViewModel>(data);
            return View(viewModel);
        }

        protected ActionResult DeleteView<TModel>(int id) where TModel : class
        {
            var data = UnitOfWork.Repository<TModel>().FindById(id);
            UnitOfWork.Repository<TModel>().Delete(data);
            return SaveAndRedirectToAction();
        }

        protected ActionResult EditView<TModel, TViewModel>(TViewModel viewModel) where TModel : class
        {
            var data = MapperFacade.Map<TModel>(viewModel);
            if (!ModelState.IsValid) return View(MapperFacade.Map<TViewModel>(data)); // Remapping to allow automapper to inject new values
            UnitOfWork.Repository<TModel>().Update(data);
            return SaveAndRedirectToAction();
        }

        protected ActionResult CreateView<TModel, TViewModel>(TViewModel viewModel) where TModel : class
        {
            var data = MapperFacade.Map<TModel>(viewModel);
            if (!ModelState.IsValid) return View(MapperFacade.Map<TViewModel>(data));  // Remapping to allow automapper to inject new values
            UnitOfWork.Repository<TModel>().Add(data);
            return SaveAndRedirectToAction();
        }

        private ActionResult SaveAndRedirectToAction()
        {
            UnitOfWork.SaveChanges();
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult IndexView<TModel, TViewModel>() where TModel : class
        {
            var data = UnitOfWork.Repository<TModel>().Get();
            var viewModel = MapperFacade.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(data);
            return View(viewModel);
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