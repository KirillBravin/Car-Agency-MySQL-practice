using Microsoft.EntityFrameworkCore;
using Cars.Core.Models;

namespace Cars.Core.Repositories
{
    public class VehicleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=vehicles_db;Integrated Security=True;TrustServerCertificate=true;");
        }
    }
}