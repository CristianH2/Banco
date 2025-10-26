using Banco.Core.Repositorio.Entidades;

namespace Banco.Core.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<int> AgregarAsync(ClienteEntidad entidad);
        Task<ClienteEntidad> ObtenerAsync(string clienteId);
        Task<ClienteEntidad> ObtenerPorCorreoAsync(string usuario);
        Task<ClienteEntidad> ObtenerPorCurpAsync(string curp);
    }
}
