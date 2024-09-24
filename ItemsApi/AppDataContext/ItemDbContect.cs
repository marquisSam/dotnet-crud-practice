using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ItemsApi.Models;

namespace ItemsApi.AppDataContext
{

    // ItemDbContext class inherits from DbContext
     public class ItemDbContext : DbContext
     {

        // DbSettings field to store the connection string
         private readonly DbSettings _dbsettings;

            // Constructor to inject the DbSettings model
         public ItemDbContext(IOptions<DbSettings> dbSettings)
         {
             _dbsettings = dbSettings.Value;
         }


        // DbSet property to represent the Item table
         public DbSet<DndItem> DndItems { get; set; }

        // DbSet property to represent the Bag table
        public DbSet<Bag> Bags { get; set; }


         // Configuring the database provider and connection string

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the model for the Item entity
            modelBuilder.Entity<DndItem>()
                .ToTable("DndItemsAPI")
                .HasKey(x => x.Id);

            // Configuring the model for the Bag entity
            modelBuilder.Entity<Bag>()
                .ToTable("BagsAPI")
                .HasKey(x => x.Id);
        }
     }
}