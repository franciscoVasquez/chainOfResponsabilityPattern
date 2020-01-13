using Microsoft.EntityFrameworkCore;

namespace EFBusinessCore.Model
{
    public class AnimalContext : DbContext
    
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
        :base(options)
        {
            
        }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(new Animal()
            {
                AnimalId = 1,
                Food = "MeatBall",
                Specie = "Dog"
            }, new Animal()
            {
                AnimalId = 2,
                Food = "Banana",
                Specie = "Monkey"
            }, new Animal()
            {
                AnimalId = 3,
                Food = "Nut",
                Specie = "Squirrel"
            });
        }

    }
}