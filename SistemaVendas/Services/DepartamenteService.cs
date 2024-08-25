using SistemaVendas.Data;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendas.Services {
    public class DepartamenteService {


        private readonly SistemaVendasContext _context;

        public DepartamenteService(SistemaVendasContext context) {
            _context = context;
        }

        public async Task<List<Departament>> FindAllAsync() {

            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
