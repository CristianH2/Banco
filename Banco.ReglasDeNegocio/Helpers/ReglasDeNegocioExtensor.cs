using Banco.Core.Interfaces;
using Banco.Core.IServices;
using Banco.ReglasDeNegocio.Reglas;
using Banco.Repsositorio.MongoDb.Helpers;
using Banco.Servicios.Renapo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.ReglasDeNegocio.Helpers
{
    public static class ReglasDeNegocioExtensor
    {
        public static void AgregarReglasDeNegocio(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AgregarRepositorioSql(configuration);
            //services.AgregarRepositorioDapper();            
            //services.AddJwtAuthentication(configuration);

            services.AgregarRepositorioMongo();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteReglasDeNEgocio, ClienteReglasDeNegocio>();
            services.AddScoped<IAhorroReglasDeNegocio, AhorroReglaDeNegocio>();
            services.AddScoped<IEstadoReglasDeNegocio,  EstadoReglasDeNegocio>();

            services.AddScoped<ICurpService, CurpServicio>();
            
        }
    }
}
