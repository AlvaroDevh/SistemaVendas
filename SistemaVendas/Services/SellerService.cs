﻿using SistemaVendas.Data;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Services.Exception;

namespace SistemaVendas.Services
{
    public class SellerService
    {

        private readonly SistemaVendasContext _context;

        public SellerService(SistemaVendasContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateException e)
            {
                throw new IntegrityException("O vendedor não pode ser apagado pois já possui registros");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("ID not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
