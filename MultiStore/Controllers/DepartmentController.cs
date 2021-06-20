using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;


namespace MultiStore.Controllers
{
    public class DepartmentController : Controller
    {
        readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
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
        public async Task<IActionResult> Create([FromForm] Department department, IFormCollection formColelction)
        {
            if (department == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Create(supplier);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)

        {

            var department = await _departmentService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Department department)
        {
            if (department == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
 
            _departmentService.Update(department);

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
