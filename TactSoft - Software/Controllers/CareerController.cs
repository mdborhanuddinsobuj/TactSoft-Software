using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TactSoft.Core.Interface;
using TactSoft.Core.Model;

namespace TactSoft___Software.Controllers
{
    public class CareerController : Controller
    {
        private readonly ICareerRepository _career;
        private readonly ICategoryRepository _category;
        private readonly INoticePeriodRepository _period;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CareerController(ICareerRepository career, ICategoryRepository category, INoticePeriodRepository period, IWebHostEnvironment webHostEnvironment)
        {
            _career = career;
            _category = category;
            _period = period;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult DataShow()
        {
            return View(_career.All().Include(x => x.NoticePeriod).Include(x => x.Category));
        }

        public IActionResult Index()
        {
            ViewData["CategoryId"] = _category.GetAllCategoryForDropDown();
            ViewData["NoticePeriodId"] = _period.GetAllNoticePeriodForDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CareerModel careerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (careerModel.ResumeUrl != null)
                    {
                        string folder = "career/pdf/";
                        folder += Guid.NewGuid().ToString() + "_" +
                            careerModel.ResumeUrl.FileName;
                        careerModel.Resume = "/" + folder;
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        await careerModel.ResumeUrl.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    }
                    _career.Insert(careerModel);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(careerModel);
            }
        }
        public IActionResult Details(int id)
        {
            var detail = _career.All()
                .Include(x=>x.Category)
                .Include(x=>x.NoticePeriod)
                .FirstOrDefault(x => x.Id == id);
            return View(detail);
        }

        public IActionResult Detele(int id)
        {
            var de = _career.All().Include(x=>x.Category).Include(x=>x.NoticePeriod).FirstOrDefault(x=>x.Id==id);
            return View(de);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CareerModel career,int id)
        {
            var de = _career.All().Include(x => x.Category).Include(x => x.NoticePeriod).FirstOrDefault(x => x.Id == id);
            if (de!=null)
            {
                _career.Delete(de);
            }
            return RedirectToAction("DataShow");
        }
        public IActionResult DownloadFile()
        {
            var memory = DownloadSinghFile("T2af99a13-7359-45bf-9d2a-51f7ea8bae37_Transactions List (1).pdf", "wwwroot\\career\\pdf");
            return File(memory.ToArray(), "application/pdf", "2af99a13-7359-45bf-9d2a-51f7ea8bae37_Transactions List (1).pdf");
        }
        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                memory = content;
            }
            memory.Position = 0;
            return memory;
        }

    }
}
