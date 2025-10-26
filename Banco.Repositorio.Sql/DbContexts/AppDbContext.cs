using Banco.Core.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Banco.Repositorio.Sql.DbContexts
{
    internal class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<AhorroEntidad> Ahorro { get; set; }
        public DbSet<ClienteEntidad> Cliente { get; set; }
        public DbSet<MovimientoEntidad> Movimiento { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
           
        }

        public AppDbContext()
        {
            _connectionString = "Server=localhost;Database=Banco;User Id=sa;Password=Macross#2012; TrustServerCertificate=True;";
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);

        }
    }
}