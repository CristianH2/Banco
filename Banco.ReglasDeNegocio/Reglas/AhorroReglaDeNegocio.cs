using Banco.Core.Dtos;
using Banco.Core.Interfaces;
using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Banco.ReglasDeNegocio.Helpers;

namespace Banco.ReglasDeNegocio.Reglas
{
    internal class AhorroReglaDeNegocio(IRepositorio repositorio) : IAhorroReglasDeNegocio
    {
        private readonly IRepositorio _repositorio = repositorio;

        public async Task<IdDto> AgregarAsync(AhorroDtoIn ahorro)
        {
            AhorroEntidad entidad;
            ClienteEntidad clienteEntidad;

            clienteEntidad = await _repositorio.Cliente.ObtenerAsync(ahorro.ClienteId);
            entidad = new AhorroEntidad
            {
                ClienteEncodedkey = clienteEntidad.EncodedKey,
                ClienteId = clienteEntidad.Id,
                Encodedkey = ahorro.Encodedkey,
                EstaActivo = true,
                FechaDeRegistro = DateTime.Now,
                Nombre = "Deposito"                
            };
            entidad.Id = await _repositorio.Ahorro.AgregarAsync(entidad);

            return new IdDto
            {
                Id = entidad.Id,
                Encodedkey = entidad.Encodedkey,
                FechaDeRegistro = DateTime.Now,
                Mensaje = "Ahorro registrado"
            };
        }

        public async Task<IdDto> DepositarAsync(MovimientoDtoIn deposito)
        {
            AhorroEntidad entidad = await _repositorio.Ahorro.ObtenerAsync(deposito.Encodedkey);

            if (entidad is null)
            {
                return new IdDto { Mensaje = "La cuenta de ahorro no existe." };
            }

            
            decimal saldoInicial = entidad.Total;
            entidad.Total += deposito.Monto;

            
            var movimiento = new MovimientoEntidad
            {
                Id = (entidad.Movimientos.Count) + 1,
                AhorroId = entidad.Id,
                AhorroEncodedkey = entidad.Encodedkey,
                Monto = deposito.Monto,
                Concepto = deposito.Concepto,
                Referencia = deposito.Referencia,
                Canal = "API",
                Tipo = "Deposito",
                FechaDeRegistro = DateTime.Now,
                SaldoInicial = saldoInicial,
                SaldoFinal = entidad.Total
            };

            entidad.Movimientos.Add(movimiento);

            await _repositorio.Ahorro.Actualizar(entidad);

            return new IdDto
            {
                Id = movimiento.Id,
                Encodedkey = entidad.Encodedkey,
                FechaDeRegistro = movimiento.FechaDeRegistro,
                Mensaje = "Deposito realizado exitosamente"
            };
        }

        public async Task<AhorroDto> ObtenerAsync(string encodedkey)
        {
            AhorroEntidad entidad;

            entidad = await _repositorio.Ahorro.ObtenerAsync(encodedkey);

            return entidad.ToDto();
        }

        public async Task<List<MovimientoDto>> ObtenerMovimientosAsync(string encodedkey)
        {
            AhorroEntidad entidad = await _repositorio.Ahorro.ObtenerAsync(encodedkey);

            if (entidad is null || entidad.Movimientos is null)
            {
                return new List<MovimientoDto>();
            }

            return entidad.Movimientos
                          .ToDto()
                          .OrderByDescending(m => m.FechaDeRegistro)
                          .ToList();
        }

        public async Task<IdDto> RetirarAsync(MovimientoDtoIn retiro)
        {
            AhorroEntidad entidad = await _repositorio.Ahorro.ObtenerAsync(retiro.Encodedkey);

            if (entidad is null)
            {
                return new IdDto { Mensaje = "La cuenta de ahorro no existe." };
            }

            if (entidad.Total < retiro.Monto)
            {
                return new IdDto
                {
                    Encodedkey = entidad.Encodedkey,
                    Mensaje = "Fondos insuficientes."
                };
            }

            decimal saldoInicial = entidad.Total;
            entidad.Total -= retiro.Monto;

            var movimiento = new MovimientoEntidad
            {
                Id = (entidad.Movimientos.Count) + 1,
                AhorroId = entidad.Id,
                AhorroEncodedkey = entidad.Encodedkey,
                Monto = retiro.Monto,
                Concepto = retiro.Concepto,
                Referencia = retiro.Referencia,
                Canal = "API",
                Tipo = "Retiro",
                FechaDeRegistro = DateTime.Now,
                SaldoInicial = saldoInicial,
                SaldoFinal = entidad.Total
            };

            entidad.Movimientos.Add(movimiento);

            await _repositorio.Ahorro.Actualizar(entidad);

            return new IdDto
            {
                Id = movimiento.Id,
                Encodedkey = entidad.Encodedkey,
                FechaDeRegistro = movimiento.FechaDeRegistro,
                Mensaje = "Retiro realizado exitosamente"
            };
        }
    }
}
