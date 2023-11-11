using CG.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Data
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Collect&Go"].ConnectionString;      //"Server=tcp:jenzvandevelde.database.windows.net,1433;Initial Catalog=CollectAndGo;Persist Security Info=False;User ID=sqlAdmin;Password=Mylo1621;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<RecipeEntity> Recipe { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<BrandEntity> Brand { get; set; }
        public DbSet<TimingEntity> Timing { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Namen van de tabellen 
            ConfigTableNames(modelBuilder);

            //Foreign Keys and column names
            ConfigTimingFKs(modelBuilder);
            ConfigProductFK(modelBuilder);
            


        }

        //Moddeling
        //Config relaties Timing
        private void ConfigTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandEntity>().ToTable("Brand");
            modelBuilder.Entity<ProductEntity>().ToTable("Product");
            modelBuilder.Entity<TimingEntity>().ToTable("Timing");
            modelBuilder.Entity<RecipeEntity>().ToTable("Recipe");
        }
        private void ConfigTimingFKs(ModelBuilder modelBuilder)
        {
                       
            modelBuilder.Entity<RecipeEntity>().HasMany(t => t.Timings).WithOne().IsRequired()     //Timing hoort sws bij een recipe (not null)
                .HasForeignKey(t =>t.RecipeId)                                                     //Gebruik t.recipeId voor deze relatie + column naam wordt RecipeId
                .HasConstraintName("FK_Recipe");                                                   //naam van de FK bepalen

            modelBuilder.Entity<TimingEntity>().HasOne(t => t.Product).WithOne().IsRequired()
                .HasForeignKey<TimingEntity>(t => t.ProductId)
                .HasConstraintName("FK_Product");

        }
        private void ConfigProductFK(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasOne(p => p.Brand).WithOne().IsRequired()
                .HasForeignKey<ProductEntity>(p => p.BrandId)
                .HasConstraintName("FK_Brand");
        }

    }
}
