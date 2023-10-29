using CG.Persistence.Model;
using Microsoft.EntityFrameworkCore;
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
        private string _connectionString;

        public RecipeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Recipe> Recipe { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        //Moddeling
    }
}
