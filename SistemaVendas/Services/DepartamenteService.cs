using SistemaVendas.Data;
using SistemaVendas.Models;

namespace SistemaVendas.Services {
    public class DepartamenteService {


        private readonly SistemaVendasContext _context;

        public DepartamenteService(SistemaVendasContext context) {
            _context = context;
        }

        public List<Departament> FindAll() {

            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}
