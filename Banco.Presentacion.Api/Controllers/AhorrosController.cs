using Banco.Core.Dtos;
using Banco.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Presentacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class AhorrosController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <summary>
        /// Crea una nueva cuenta de ahorros para un cliente.
        /// </summary>
        /// <remarks>
        /// Requiere autenticación JWT (Token de Cliente).
        /// </remarks>
        /// <param name="ahorro">Datos de la nueva cuenta.</param>
        /// <returns>Un IdDto con el ID de la nueva cuenta.</returns>
        [HttpPost]
        [ProducesResponseType<IdDto>(201)]
        public async Task<IActionResult> AgregarAsync(AhorroDtoIn ahorro)
        {
            AhorroDto ahorroDto;

            ahorroDto = await _unitOfWork.Ahorro.ObtenerAsync(ahorro.Encodedkey);
            if (ahorroDto is not null)
            {
                return StatusCode(208, new IdDto
                {
                    Encodedkey = ahorroDto.Encodedkey,
                    FechaDeRegistro = ahorroDto.FechaDeRegistro,
                    Id = ahorroDto.Id,
                    Mensaje = "Ahorro registrado previamente"
                });
            }

            IdDto idDto;

            idDto = await _unitOfWork.Ahorro.AgregarAsync(ahorro);

            return Created(string.Empty, idDto);
        }

        /// <summary>
        /// Realiza un depósito a una cuenta de ahorros específica.
        /// </summary>
        /// <remarks>
        /// Requiere autenticación JWT (Token de Cliente).
        /// </remarks>
        /// <param name="deposito">Datos del movimiento (Monto, Concepto, Encodedkey de la cuenta).</param>
        /// <returns>Un IdDto confirmando la transacción.</returns>
        [HttpPost("/Depositos")]
        [ProducesResponseType<IdDto>(201)]
        public async Task<IActionResult> DespositarAsync(MovimientoDtoIn deposito)
        {
            IdDto idDto;
            idDto = await _unitOfWork.Ahorro.DepositarAsync(deposito);

            return Created(string.Empty, idDto);
        }


        /// <summary>
        /// Realiza un retiro de una cuenta de ahorros específica.
        /// </summary>
        /// <remarks>
        /// Requiere autenticación JWT (Token de Cliente). Validará que haya fondos suficientes.
        /// </remarks>
        /// <param name="retiro">Datos del movimiento (Monto, Concepto, Encodedkey de la cuenta).</param>
        /// <returns>Un IdDto confirmando la transacción.</returns>
        [HttpPost("/Retiros")]
        [ProducesResponseType<IdDto>(201)]
        public async Task<IActionResult> RetirarAsync(MovimientoDtoIn retiro)
        {
            IdDto idDto;
            idDto = await _unitOfWork.Ahorro.RetirarAsync(retiro);

            if (idDto.Id == 0)
            {
                return BadRequest(idDto);
            }
            return Created(string.Empty, idDto);
        }

        /// <summary>
        /// Obtiene los detalles y el saldo de una cuenta de ahorro específica.
        /// </summary>
        /// <param name="encodedkey">El identificador único (GUID) de la cuenta de ahorro.</param>
        /// <returns>Los detalles de la cuenta de ahorro, incluyendo el saldo total.</returns>
        [HttpGet("{encodedkey}")]
        [ProducesResponseType(typeof(AhorroDto), 200)]
        public async Task<IActionResult> ObtenerAhorroAsync(string encodedkey)
        {
            AhorroDto ahorroDto = await _unitOfWork.Ahorro.ObtenerAsync(encodedkey);

            if (ahorroDto is null)
            {
                return NotFound(new { Mensaje = "Cuenta de ahorro no encontrada." });
            }

            return Ok(ahorroDto);
        }

        /// <summary>
        /// Obtiene el historial de movimientos (depósitos y retiros) de una cuenta.
        /// </summary>
        /// <param name="encodedkey">El identificador único (GUID) de la cuenta de ahorro.</param>
        /// <returns>Una lista de los movimientos de la cuenta.</returns>
        [HttpGet("{encodedkey}/movimientos")]
        [ProducesResponseType(typeof(IEnumerable<MovimientoDto>), 200)]
        public async Task<IActionResult> ObtenerMovimientosAsync(string encodedkey)
        {
            var movimientos = await _unitOfWork.Ahorro.ObtenerMovimientosAsync(encodedkey);

            return Ok(movimientos);
        }
    }
}
