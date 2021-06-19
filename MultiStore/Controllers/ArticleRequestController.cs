using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class ArticleRequestController : Controller
    {
        readonly IArticleRequestService _articleRequestService;

        public ArticleRequestController(IArticleRequestService articleRequestService)
        {
            _articleRequestService = articleRequestService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _articleRequestService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _articleRequestService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ArticleRequest supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleRequestService.Create(supplier);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] ArticleRequest supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            _articleRequestService.Delete(supplier.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _articleRequestService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] ArticleRequest supplier)
        {
            if (supplier.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleRequestService.Delete(supplier.Id);
            return RedirectToAction("Index");
        }
    }
}
