using Microsoft.EntityFrameworkCore;
using PlantData.API.Models.Domian;

namespace PlantData.API.Data
{
    public class PlantDataDbContext : DbContext
    {
        public PlantDataDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Family> Families { get; set; }

    }
}
