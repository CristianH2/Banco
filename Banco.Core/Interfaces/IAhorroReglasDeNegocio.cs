using Banco.Core.Dtos;

namespace Banco.Core.Interfaces
{
    public interface IAhorroReglasDeNegocio
    {
        Task<IdDto> AgregarAsync(AhorroDtoIn ahorro);

        Task<IdDto> DepositarAsync(MovimientoDtoIn deposito);
        Task<AhorroDto> ObtenerAsync(string encodedkey);
        Task<IdDto> RetirarAsync(MovimientoDtoIn retiro);
        Task<List<MovimientoDto>> ObtenerMovimientosAsync(string encodedkey);
    }
}
