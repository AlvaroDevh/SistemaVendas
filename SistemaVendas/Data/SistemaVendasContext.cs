using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;

namespace SistemaVendas.Data
{
    public class SistemaVendasContext : DbContext
    {
        public SistemaVendasContext (DbContextOptions<SistemaVendasContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaVendas.Models.Departament> Departament { get; set; } = default!;
    }
}
