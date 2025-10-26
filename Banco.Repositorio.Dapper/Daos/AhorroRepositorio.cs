using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;

namespace Banco.Repositorio.Dapper.Daos
{
    public class AhorroRepositorio : IAhorroRepositorio
    {
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
