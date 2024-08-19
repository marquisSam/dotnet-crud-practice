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

         // Configuring the database provider and connection string

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
         }

            // Configuring the model for the Item entity
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<DndItem>()
                 .ToTable("DndItemsAPI")
                 .HasKey(x => x.Id);
         }
     }
}