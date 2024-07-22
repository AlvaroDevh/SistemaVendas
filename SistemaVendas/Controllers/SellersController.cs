using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Services;

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
    }
}
