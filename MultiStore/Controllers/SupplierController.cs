using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class SupplierController : Controller
    {
        readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int id)
        {
            var data = await _supplierService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> Get()
        {
            var data = await _supplierService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _supplierService.Create(supplier);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _supplierService.Update(supplier);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _supplierService.Delete(id);
            return View();
        }
    }
}
