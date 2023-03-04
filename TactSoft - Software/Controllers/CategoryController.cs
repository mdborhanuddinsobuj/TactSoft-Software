using Microsoft.AspNetCore.Mvc;
using TactSoft.Core.Interface;
using TactSoft.Core.Model;

namespace TactSoft___Software.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            return View(_category.All());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _category.Insert(category);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
        public IActionResult Edit(int id)
        {
            return View(_category.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _category.Update(category,category.Id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var de = _category.Find(id);
            return View(de);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            try
            {
                var de = _category.Find(category.Id);
                if (de != null)
                {
                    _category.Delete(de);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
    }
}
