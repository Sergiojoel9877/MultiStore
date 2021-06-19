using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public async Task<IActionResult> Index()
        {
            var data = await _articleService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _articleService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Article Article)
        {
            if (Article == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleService.Create(Article);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Article Article)
        {
            if (Article == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            Article s = new Article()
            {
                Id = Article.Id,
                Articles = Article.Articles,
                ArticleRequests = Article.ArticleRequests,
                CreatedDate = Article.CreatedDate,
                IsActive = Article.IsActive,
                LastUpdatedDate = Article.LastUpdatedDate,
            };
            _articleService.Delete(Article.Id);
            _articleService.Create(s);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _articleService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] Article Article)
        {
            if (Article.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _articleService.Delete(Article.Id);
            return RedirectToAction("Index");
        }
    }
}
