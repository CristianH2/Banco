using Banco.Core.Repositorio.Interfaces;
using Banco.Repsositorio.MongoDb.Daos;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Repsositorio.MongoDb.Helpers
{
    public static class RepositorioMongoDbExtensor
    {
        public static void AgregarRepositorioMongo(this IServiceCollection services)
        {
            services.AddScoped<IRepositorio, RepositorioMongo>();
            services.AddScoped<IAhorroRepositorio, AhorroRepo>();
            services.AddScoped<IClienteRepositorio, ClienteRepo>();
        }
    }
}
