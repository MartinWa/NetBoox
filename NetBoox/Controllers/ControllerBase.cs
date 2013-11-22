using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Repository;

namespace NetBoox.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected ActionResult FindView<TModel, TViewModel>(int? id) where TModel : class
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _unitOfWork.Repository<TModel>().FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<TViewModel>(book);
            return View(viewModel);
        }

        protected ActionResult DeleteView<TModel>(int id) where TModel : class
        {
            var book = _unitOfWork.Repository<TModel>().FindById(id);
            _unitOfWork.Repository<TModel>().Delete(book);
            _unitOfWork.SaveChanges();
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult EditView<TModel, TViewModel>(TViewModel bookViewModel) where TModel : class
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<TModel>(bookViewModel);
                _unitOfWork.Repository<TModel>().Update(book);
                _unitOfWork.SaveChanges();
                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                return RedirectToAction("Index", controllerName);
            }
            return View(bookViewModel);
        }

        protected ActionResult CreateView<TModel, TViewModel>(TViewModel bookViewModel) where TModel : class
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<TModel>(bookViewModel);
                _unitOfWork.Repository<TModel>().Add(book);
                _unitOfWork.SaveChanges();
                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                return RedirectToAction("Index", controllerName);
            }
            return View(bookViewModel);
        }

        protected ActionResult IndexView<TModel, TViewModel>() where TModel : class
        {
            var books = _unitOfWork.Repository<TModel>().Get();
            var booksViewModel = Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(books);
            return View(booksViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}