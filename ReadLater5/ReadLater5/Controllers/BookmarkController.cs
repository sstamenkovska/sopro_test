using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    public class BookmarkController : Controller
    {
        private IBookmarkService _bookmarkService;
        private ICategoryService _categoryService;
        public BookmarkController(IBookmarkService bookmarkService, ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }
        // GET: BookmarkController
        public ActionResult Index()
        {
            List<Bookmark> model = _bookmarkService.GetBookmarks();
            return View(model);
        }

        // GET: BookmarkController/Details/5
        public ActionResult Details(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            var category = bookmark.Category;
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // GET: BookmarkController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            return View();
        }

        // POST: BookmarkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bookmark bookmark, string categoryName)
        {
            if (ModelState.IsValid)
            {
                if(bookmark.CategoryId == null && !string.IsNullOrWhiteSpace(categoryName))
                {
                    //we have a new category, create it and then assign the bookmark to it
                    var newCategory = _categoryService.CreateCategory(new Category
                    {
                        Name = categoryName
                    });
                    bookmark.CategoryId = newCategory.ID;
                }
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: BookmarkController/Edit/5
        public ActionResult Edit(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            ViewBag.Categories = _categoryService.GetCategories();
            return View(bookmark);
        }

        // POST: BookmarkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: BookmarkController/Delete/5
        public ActionResult Delete(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: BookmarkController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction("Index");
        }
    }
}
