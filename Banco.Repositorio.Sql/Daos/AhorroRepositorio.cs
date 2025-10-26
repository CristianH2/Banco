using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Banco.Repositorio.Sql.DbContexts;

namespace Banco.Repositorio.Sql.Daos
{
    internal class AhorroRepositorio(AppDbContext appDbContext) : IAhorroRepositorio
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public Task Actualizar(AhorroEntidad entidad)
        {
            throw new NotImplementedException();
        }

        public Task<int> AgregarAsync(AhorroEntidad entidad)
        {
            throw new NotImplementedException();
        }

        public Task<AhorroEntidad> ObtenerAsync(string idEncodedKey)
        {
            throw new NotImplementedException();
        }
    }
}
