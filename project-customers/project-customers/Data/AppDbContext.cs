using Microsoft.EntityFrameworkCore;
using project_customers.Models;
using System.Collections.Generic;

namespace project_customers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClientesModel> Clientes { get; set; }
    }
}
