using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Services;
using SistemaVendas.Models;
using SistemaVendas.Models.ViewModels;

namespace SistemaVendas.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _sellerService;
        private readonly DepartamenteService _departamenteService;


        public SellersController(SellerService SS, DepartamenteService DS) {
            _sellerService = SS;
            _departamenteService = DS;
        }
        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            var departaments = _departamenteService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
