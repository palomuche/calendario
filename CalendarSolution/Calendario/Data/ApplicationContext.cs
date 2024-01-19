using Calendario.Domain;
using Microsoft.EntityFrameworkCore;

namespace Calendario.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Teste> Testes { get; set; }    
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=Calendario;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>();
        }
    }
}
