using Microsoft.EntityFrameworkCore;
using rmz_meter_project.Models.Domain;

namespace rmz_meter_project.MeterDbcontext
{
    public class meterDbContext : DbContext
    {
        public meterDbContext(DbContextOptions<meterDbContext>options):base(options)
        {

        }
        public DbSet<City> cities { get; set; }
        public DbSet<Facility> facilities { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Floor> floors { get; set; }
        public DbSet<Zone> zones { get; set; }
        public DbSet<meter> meters { get; set; }
        
    }
}
