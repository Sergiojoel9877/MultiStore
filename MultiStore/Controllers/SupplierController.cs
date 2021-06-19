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
    public class SupplierController : Controller
    {
        readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _supplierService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _supplierService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Supplier supplier, IFormCollection formColelction)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _supplierService.Create(supplier);
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Supplier supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            Supplier s = new Supplier()
            {
                Id = supplier.Id,
                 Articles = supplier.Articles,
                  CommercialName = supplier.CommercialName,
                   CreatedDate = supplier.CreatedDate,
                    IsActive = supplier.IsActive,
                     LastUpdatedDate = supplier.LastUpdatedDate,
                      NationalTaxPayerRegistry = supplier.NationalTaxPayerRegistry

            };
            _supplierService.Delete(supplier.Id);
            _supplierService.Create(s);
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _supplierService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] Supplier supplier)
        {
            if (supplier.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _supplierService.Delete(supplier.Id);
            return View();
        }
    }
}
