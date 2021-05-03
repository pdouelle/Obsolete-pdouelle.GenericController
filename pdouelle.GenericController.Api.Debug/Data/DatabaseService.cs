using Microsoft.EntityFrameworkCore;
using pdouelle.GenericController.Api.Debug.Models.Animals.Entities;
using pdouelle.GenericController.Api.Debug.Models.Insects.Entities;

namespace pdouelle.GenericController.Api.Debug.Data
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Insect> Insects { get; set; }
    }
}