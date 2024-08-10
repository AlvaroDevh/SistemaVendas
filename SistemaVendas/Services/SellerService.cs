using SistemaVendas.Data;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendas.Services {
    public class SellerService {

        private readonly SistemaVendasContext _context;

        public SellerService ( SistemaVendasContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Sellers.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
