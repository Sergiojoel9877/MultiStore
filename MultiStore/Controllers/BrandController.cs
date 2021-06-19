using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class BrandController : Controller
    {
        readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int id)
        {
            var data = await _brandService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> Get()
        {
            var data = await _brandService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Post([FromBody] Brand brand)
        {
            if (brand == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _brandService.Create(brand);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] Brand brand)
        {
            if (brand == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _brandService.Update(brand);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _brandService.Delete(id);
            return View();
        }
    }
}
