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
    public class DepartmentController : Controller
    {
        readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService supplierService)
        {
            _departmentService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _departmentService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _departmentService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Department supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Create(supplier);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Department supplier)
        {
            if (supplier == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            Department s = new Department()
            {
                Id = supplier.Id,
               
                CreatedDate = supplier.CreatedDate,
                IsActive = supplier.IsActive,
                LastUpdatedDate = supplier.LastUpdatedDate,
            };
            _departmentService.Delete(supplier.Id);
            _departmentService.Create(s);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _departmentService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] Department supplier)
        {
            if (supplier.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Delete(supplier.Id);
            return RedirectToAction("Index");
        }
    }
}
