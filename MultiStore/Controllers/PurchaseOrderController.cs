using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiStore.Controllers
{
    public class PurchaseOrderController : Controller
    {
        readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        public  async Task<IActionResult> Index()
        {
            var data = await _purchaseOrderService.GetAll();
            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _purchaseOrderService.Get(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
                return View(new ErrorViewModel { RequestId = Activity.Current.Id });
            await _purchaseOrderService.Create(purchaseOrder);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var purchaseOrder = await _purchaseOrderService.Get(id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        public async Task<IActionResult> Get()
        {
            if (purchaseOrder == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _purchaseOrderService.Create(purchaseOrder);
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _purchaseOrderService.Get(id);
            return View(data.Result);
        }

        public async Task<IActionResult> Delete([FromForm] PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _purchaseOrderService.Delete(purchaseOrder.Id);
            return RedirectToAction("Index");
        }
    }
}
