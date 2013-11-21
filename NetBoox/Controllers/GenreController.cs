using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using NetBoox.ViewModels;
using Repository;

namespace NetBoox.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var genres = _unitOfWork.Repository<Genre>().Get();
            var genreViewModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);
            return View(genreViewModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = _unitOfWork.Repository<Genre>().FindById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            var genreViewModel = Mapper.Map<GenreViewModel>(genre);
            return View(genreViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = Mapper.Map<Genre>(genreViewModel);
                _unitOfWork.Repository<Genre>().Add(genre);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = _unitOfWork.Repository<Genre>().FindById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            var genreViewModel = Mapper.Map<GenreViewModel>(genre);
            return View(genreViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = Mapper.Map<Genre>(genreViewModel);
                _unitOfWork.Repository<Genre>().Update(genre);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreViewModel);
        }

        // GET: /Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genre = _unitOfWork.Repository<Genre>().FindById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            var genreViewModel = Mapper.Map<GenreViewModel>(genre);
            return View(genreViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var genre = _unitOfWork.Repository<Genre>().FindById(id);
            _unitOfWork.Repository<Genre>().Delete(genre);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
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
