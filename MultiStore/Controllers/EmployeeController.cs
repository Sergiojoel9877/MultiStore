using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int id)
        {
            var data = await _employeeService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> Get()
        {
            var data = await _employeeService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _employeeService.Create(employee);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            if (employee == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _employeeService.Update(employee);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _employeeService.Delete(id);
            return View();
        }
    }
}
