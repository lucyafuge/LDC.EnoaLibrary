using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDC.EnoaLibrary.Data
{
    internal class SignContext : DbContext
    {
        public string? ConnectionString { get; set; }
        public DbSet<Sign> Signs => Set<Sign>();

        public SignContext(string connectionString)
        {
            ConnectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
