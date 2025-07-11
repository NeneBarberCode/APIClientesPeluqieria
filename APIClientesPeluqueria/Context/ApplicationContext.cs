using APIClientesPeluqueria.Models;
using Microsoft.EntityFrameworkCore;

namespace APIClientesPeluqueria.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HairCut> hairCuts { get; set; }
        public DbSet<CustomerHaircut> customerHaircuts { get; set; }

    }
}
