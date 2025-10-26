using Banco.Core.Dtos;

namespace Banco.Core.Interfaces
{
    public interface IEstadoReglasDeNegocio
    {
        List<EstadoDto> Obtener();
        string ObtenerPorId(int estadoDeNacimiento);
    }
}
