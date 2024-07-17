using Microsoft.AspNetCore.Mvc;

namespace SistemaVendas.Controllers {
    public class SellersController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
