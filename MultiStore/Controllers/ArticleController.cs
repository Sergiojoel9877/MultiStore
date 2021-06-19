using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class ArticleController : Controller
    {
        readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int id)
        {
            var data = await _articleService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> Get()
        {
            var data = await _articleService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Post([FromBody] Article article)
        {
            if(article == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleService.Create(article);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] Article article)
        {
            if (article == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleService.Update(article);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleService.Delete(id);
            return View();
        }
    }
}
