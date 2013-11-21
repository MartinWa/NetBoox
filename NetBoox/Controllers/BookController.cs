﻿using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using NetBoox.ViewModels;
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
            var books = _unitOfWork.Repository<Book>().Get();
            var booksViewModel = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            return View(booksViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _unitOfWork.Repository<Book>().FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = Mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<Book>(bookViewModel);
                _unitOfWork.Repository<Book>().Add(book);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _unitOfWork.Repository<Book>().FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = Mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<Book>(bookViewModel);
                _unitOfWork.Repository<Book>().Update(book);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _unitOfWork.Repository<Book>().FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = Mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = _unitOfWork.Repository<Book>().FindById(id);
            _unitOfWork.Repository<Book>().Delete(book);
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
