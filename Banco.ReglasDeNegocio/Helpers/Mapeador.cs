using Banco.Core.Dtos;
using Banco.Core.Repositorio.Entidades;

namespace Banco.ReglasDeNegocio.Helpers
{
    public static class Mapeador
    {
        public static ClienteDto ToDto(this ClienteEntidad entidad) => entidad is null ? null : new ClienteDto
        {
            Correo = entidad.Correo,
            EncodedKey = entidad.EncodedKey,
            EstadoDeNacimiento = entidad.EstadoDeNacimiento,
            FechaDeNacimiento = entidad.FechaDeNacimiento,
            FechaDeRegistro = entidad.FechaDeRegistro,
            Id = entidad.Id,
            Nombre = entidad.Nombre,
            PrimerApellido = entidad.PrimerApellido,
            SegundoApellido = entidad.SegundoApellido,
            Telefono = entidad.Telefono
        };

        public static ClienteEntidad ToEntidad(this ClienteDtoIn cliente) => new ClienteEntidad
        {
            Correo = cliente.Correo,
            EncodedKey = cliente.EncodedKey,
            EstaActivo = true,
            EstadoDeNacimiento = cliente.EstadoDeNacimiento.ToString(),
            FechaDeNacimiento = cliente.FechaDeNacimiento,
            FechaDeRegistro = DateTime.Now,
            Nombre = cliente.Nombre,
            PrimerApellido = cliente.PrimerApellido,
            SegundoApellido = cliente.SegundoApellido,
            Telefono = cliente.Telefono,
            Contrasenia = cliente.Contrasenia
        };

        public static AhorroDto ToDto(this AhorroEntidad entidad) => entidad is null ? null : new AhorroDto
        {
            ClienteId = entidad.ClienteId,
            Encodedkey = entidad.Encodedkey,
            FechaDeRegistro = entidad.FechaDeRegistro,
            Id = entidad.Id,
            Total = entidad.Total,
        };

        public static SolicitudDto ToSolicitudDeCurp(this ClienteDtoIn dtoIn) => new SolicitudDto
        {
            FechaDeNacimiento = dtoIn.FechaDeNacimiento,
            Estado = string.Empty,// ObtenerEstado(dtoIn.EstadoDeNacimiento),
            Nombres = dtoIn.Nombre,
            primerApellido = dtoIn.PrimerApellido,
            segundoApellido = dtoIn.SegundoApellido,
            Sexo = dtoIn.Sexo
        };

        public static MovimientoDto ToDto(this MovimientoEntidad entidad) => entidad is null ? null : new MovimientoDto
        {
            Id = entidad.Id,
            Concepto = entidad.Concepto,
            FechaDeRegistro = entidad.FechaDeRegistro,
            Monto = entidad.Monto,
            Referencia = entidad.Referencia,
            SaldoFinal = entidad.SaldoFinal,
            SaldoInicial = entidad.SaldoInicial,
            Tipo = entidad.Tipo
        };

        public static List<MovimientoDto> ToDto(this List<MovimientoEntidad> entidades)
        {
            return entidades?.Select(e => e.ToDto()).ToList() ?? new List<MovimientoDto>();
        }
    }
}
