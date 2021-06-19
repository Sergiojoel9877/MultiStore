using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

namespace MultiStore.Controllers
{
    public class BrandController : Controller
    {
        readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _brandService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _brandService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Brand brand)
        {
            if (brand == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _brandService.Create(brand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandService.Get(id);

            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Brand brand)
        {
            if (brand == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            _brandService.Update(brand);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _brandService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] Brand brand)
        {
            if (brand.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _brandService.Delete(brand.Id);
            return RedirectToAction("Index");
        }
    }
}
