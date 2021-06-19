using System.Diagnostics;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetById(int id)
        {
            var data = await _articleRequestService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> GetAll()
        {
            var data = await _articleRequestService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> PostArticle([FromBody] ArticleRequest articleRequest)
        {
            if (articleRequest == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleRequestService.Create(articleRequest);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] ArticleRequest articleRequest)
        {
            if (articleRequest == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleRequestService.Update(articleRequest);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleRequestService.Delete(id);
            return View();
        }
    }
}
