using Banco.Core.Repositorio.Interfaces;
using Banco.Repositorio.Sql.Daos;
using Banco.Repositorio.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Repositorio.Sql.Helpers
{
    public static class SqlExtensor
    {
        public static void AgregarRepositorioSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => { 
                var connectionString = configuration.GetConnectionString("Banco");
                options.UseSqlServer(configuration.GetConnectionString("Banco"));
            });

            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IAhorroRepositorio, AhorroRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        }
    }
}
