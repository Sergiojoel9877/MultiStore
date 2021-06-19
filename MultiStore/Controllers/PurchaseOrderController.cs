using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Services;
using MultiStore.Models;

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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetById(int id)
        {
            var data = await _purchaseOrderService.Get(id);
            return View(data);
        }

        public async Task<IActionResult> GetAll()
        {
            var data = await _purchaseOrderService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> PostArticle([FromBody] PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _purchaseOrderService.Create(purchaseOrder);
            return View();
        }

        public async Task<IActionResult> Put([FromBody] PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _purchaseOrderService.Update(purchaseOrder);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            await _purchaseOrderService.Delete(id);
            return View();
        }
    }
}
