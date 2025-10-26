using Banco.Core.Repositorio.Interfaces;
using Banco.Repositorio.Dapper.Daos;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Repositorio.Dapper.Helpers
{
    public static class RepositorioDapperExtensor
    {
        public static void AgregarRepositorioDapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositorio, RepositorioDapper>();
            services.AddScoped<IAhorroRepositorio, AhorroRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        }
    }
}
