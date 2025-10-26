using Banco.Core.Dtos;

namespace Banco.Core.IServices
{
    public interface ICurpService
    {
        Task<string> GenerarCurp(SolicitudDto solicitudDeCurpDto);
    }
}
