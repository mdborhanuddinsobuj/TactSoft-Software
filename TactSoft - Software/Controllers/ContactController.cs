using Microsoft.AspNetCore.Mvc;
using TactSoft.Core.Interface;
using TactSoft.Core.Model;

namespace TactSoft___Software.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contact;
        public ContactController(IContactRepository contact)
        {
            _contact = contact;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contact.Insert(contact);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult ContactShow()
        {
            return View(_contact.All());
        }
        public IActionResult Details(int id)
        {
            var details = _contact.Find(id);
            return View(details);
        }
        
    }
}
