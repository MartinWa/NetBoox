﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using NetBoox.AutoMapper;
using Repository.Abstract;

namespace NetBoox.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapperFacade MapperFacade;
        private readonly IDataCache _dataCache;

        protected ControllerBase(IUnitOfWork unitOfWork, IMapperFacade mapperFacade, IDataCache dataCache)
        {
            UnitOfWork = unitOfWork;
            MapperFacade = mapperFacade;
            _dataCache = dataCache;
            _dataCache.SetNewDefaultAbsoluteExpiration(DateTimeOffset.Now.AddSeconds(20));
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
            return SaveAndRedirectToAction<TModel>();
        }

        protected ActionResult EditView<TModel, TViewModel>(TViewModel viewModel) where TModel : class
        {
            var data = MapperFacade.Map<TModel>(viewModel);
            if (!ModelState.IsValid) return View(MapperFacade.Map<TViewModel>(data)); // Remapping to allow automapper to inject new values
            UnitOfWork.Repository<TModel>().Update(data);
            return SaveAndRedirectToAction<TModel>();
        }

        protected ActionResult CreateView<TModel, TViewModel>(TViewModel viewModel) where TModel : class
        {
            var data = MapperFacade.Map<TModel>(viewModel);
            if (!ModelState.IsValid)
            {
                return View(MapperFacade.Map<TViewModel>(data));  // Remapping to allow automapper to inject new values
            }
            UnitOfWork.Repository<TModel>().Add(data);
            return SaveAndRedirectToAction<TModel>();
        }

        private ActionResult SaveAndRedirectToAction<TModel>()
        {
            UnitOfWork.SaveChanges();
            _dataCache.Remove<TModel>(); // Clear the cache as we have change a value
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return RedirectToAction("Index", controllerName);
        }

        protected ActionResult IndexView<TModel, TViewModel>() where TModel : class
        {
            var data = UnitOfWork.Repository<TModel>().Get();
            var viewModel = MapperFacade.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(data);
            return View(viewModel);
        }

        protected ActionResult IndexViewCached<TModel, TViewModel>() where TModel : class
        {
            var data = _dataCache.Get<TModel>();
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