using CG.DL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString = "Data Source=.;Initial Catalog=Collect&Go;Integrated Security=True; TrustServerCertificate=True";    //"Server=tcp:jenzvandevelde.database.windows.net,1433;Initial Catalog=CollectAndGo;Persist Security Info=False;User ID=sqlAdmin;Password=Mylo1621;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbSet<RecipeEntity> Recipe { get; set; }            //naam van de tabel in de database
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<BrandEntity> Brand { get; set; }
        public DbSet<TimingEntity> Timing { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);




        }

        //Moddeling
    }
}
