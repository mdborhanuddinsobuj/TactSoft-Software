using Microsoft.AspNetCore.Mvc;
using TactSoft.Core.Interface;
using TactSoft.Core.Model;

namespace TactSoft___Software.Controllers
{
    public class NoticePeriodController : Controller
    {
        private readonly INoticePeriodRepository _periodRepository;

        public NoticePeriodController(INoticePeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        public IActionResult Index()
        {
            return View(_periodRepository.All());
        }
        public IActionResult Create(int id)
        {
            return View(_periodRepository.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoticePeriod notice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _periodRepository.Insert(notice);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(notice);
            }
        }
        public IActionResult Edit(int id)
        {
            var notice = _periodRepository.Find(id);
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NoticePeriod notice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _periodRepository.Update(notice,notice.Id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(notice);
            }
        }
        public IActionResult Delete(int id)
        {
            var de = _periodRepository.Find(id);
            return View(de);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(NoticePeriod notice,int id)
        {
            var de = _periodRepository.Find(id);
            if (de!=null)
            {
                _periodRepository.Delete(de);
            }
            return RedirectToAction("Index");
        }
    }
}
