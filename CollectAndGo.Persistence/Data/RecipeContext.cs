using CG.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Data
{
    public class RecipeContext : DbContext
    {
        private string _connectionString = "Server=tcp:jenzvandevelde.database.windows.net,1433;Initial Catalog=CollectAndGo;Persist Security Info=False;User ID=sqlAdmin;Password=Mylo1621;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbSet<Recipe> Recipe { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        //Moddeling
    }
}
