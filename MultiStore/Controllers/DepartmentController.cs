using System.Diagnostics;
using System.Threading.Tasks;
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

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetById(int id)
        {
            var data = await _departmentService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> GetAll()
        {
            var data = await _departmentService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> PostArticle([FromBody] Department department)
        {
            if (department == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Create(department);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] Department department)
        {
            if (department == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Update(department);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _departmentService.Delete(id);
            return View();
        }
    }
}
