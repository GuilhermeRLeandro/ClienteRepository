using Microsoft.EntityFrameworkCore;
using RegistroDeClientes.Domain.Entities;

namespace RegistroDeClientes.Infra
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DataBase");
            optionsBuilder.UseSqlite(connectionString);
        }
        public DataContext(DbContextOptions<DataContext> Options) : base(Options) {}
        public DbSet<Cliente> Clientes { get; set; }
    }
}
