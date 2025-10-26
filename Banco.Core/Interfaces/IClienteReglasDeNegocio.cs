using Banco.Core.Dtos;
using System.Threading.Tasks;

namespace Banco.Core.Interfaces
{
    public interface IClienteReglasDeNEgocio
    {
        Task<IdDto> AgregarAsync(ClienteDtoIn cliente);
        Task<TokenDto> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion);
        Task<ClienteDto> ObtenerAsync(ClienteDtoIn cliente);
        Task<ClienteDto> ObtenerPorIdAsync(int clienteId);
    }
}
