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
    public class UnitMeasurementController : Controller
    {
        readonly IUnitMeasurementService _unitMeasurementService;

        public UnitMeasurementController(IUnitMeasurementService supplierService)
        {
            _unitMeasurementService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _unitMeasurementService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _unitMeasurementService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UnitMeasurement unitMeasurement, IFormCollection formColelction)
        {
            if (unitMeasurement == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _unitMeasurementService.Create(unitMeasurement);
            return View();
        }

        public async Task<IActionResult> Edit(int id)

        {
           
            var unitmeasurement = await _unitMeasurementService.Get(id);

            if (unitmeasurement == null)
            {
                return NotFound();
            }

            return View(unitmeasurement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] UnitMeasurement unitMeasurement)
        {
            if (unitMeasurement == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

 
            _unitMeasurementService.Update(unitMeasurement);

            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _unitMeasurementService.Get(id);
            return View(data.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] UnitMeasurement unitMeasurement)
        {
            if (unitMeasurement.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _unitMeasurementService.Delete(unitMeasurement.Id);
            return View();
        }
    }
}
