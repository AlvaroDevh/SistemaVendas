using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Services;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _SellerService;

        public SellersController (SellerService SS) {
            _SellerService = SS;
        }
        public IActionResult Index() {
            var list = _SellerService.FindAll();
            return View(list);
        }

        public IActionResult  Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
