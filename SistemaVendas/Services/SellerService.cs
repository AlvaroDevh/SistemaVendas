using SistemaVendas.Data;
using SistemaVendas.Models;

namespace SistemaVendas.Services {
    public class SellerService {

        private readonly SistemaVendasContext _context;

        public SellerService ( SistemaVendasContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Sellers.ToList();
        }
    }
}
