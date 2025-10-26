using Banco.Core.Repositorio.Entidades;

namespace Banco.Core.Repositorio.Interfaces
{
    public interface IAhorroRepositorio
    {
        Task<int> AgregarAsync(AhorroEntidad entidad);

        Task<AhorroEntidad> ObtenerAsync(string idEncodedKey);

        Task Actualizar(AhorroEntidad entidad);
    }
}
