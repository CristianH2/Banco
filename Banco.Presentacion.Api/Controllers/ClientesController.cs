using Banco.Core.Dtos;
using Banco.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Presentacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <summary>
        /// Registra un nuevo cliente en el sistema.
        /// </summary>
        /// <remarks>
        /// Recibe los datos del cliente, genera un CURP, lo guarda en la base de datos y le crea una cuenta de ahorros inicial.
        /// </remarks>
        /// <param name="cliente">Datos del cliente para el registro (ClienteDtoIn).</param>
        /// <returns>Un IdDto con el ID y EncodedKey del cliente creado.</returns>
        [HttpPost]
        [ProducesResponseType<IdDto>(201)]
        public async Task<IActionResult> AgregarAsync(ClienteDtoIn cliente)
        {
            IdDto idDto;
            ClienteDto clienteDto = await _unitOfWork.Cliente.ObtenerAsync(cliente);
            
            if (clienteDto is not null)
            {
                idDto = new IdDto
                {
                    Encodedkey = cliente.EncodedKey,
                    Id = clienteDto.Id,
                    Mensaje = "Registro previo"
                };
                return StatusCode(208, idDto);
            }

            idDto = await _unitOfWork.Cliente.AgregarAsync(cliente);

            return Created("", idDto);
        }

        /// <summary>
        /// Inicia sesión de un cliente y genera un token JWT.
        /// </summary>
        /// <param name="inicioDeSesion">Credenciales (usuario/correo y contraseña).</param>
        /// <returns>Un TokenDto con el token JWT si las credenciales son válidas.</returns>
        [HttpPost("InicioDeSesiones")]
        [AllowAnonymous]
        [ProducesResponseType<TokenDto>(201)]
        [Produces("application/json")]
        public async Task<IActionResult> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion)
        {
            TokenDto tokenDto = await _unitOfWork.Cliente.IniciarSesionAsync(inicioDeSesion);
            if (tokenDto is null)
            {
                return StatusCode(400, new IdDto { Mensaje = "Credenciales no validas" });
            }

            return Ok(tokenDto);
        }

        /// <summary>
        /// Obtiene los datos del perfil del cliente actualmente autenticado.
        /// </summary>
        /// <returns>Los datos del perfil del cliente.</returns>
        [HttpGet("Perfil")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        [ProducesResponseType<ClienteDto>(200)]
        public async Task<IActionResult> ObtenerPerfil()
        {
            var idClaim = User.Claims.FirstOrDefault(c => c.Type == "ClienteId");

            if (idClaim is null || !int.TryParse(idClaim.Value, out int clienteId))
            {
                return Unauthorized("Token inválido o no contiene ClienteId.");
            }

            ClienteDto clienteDto = await _unitOfWork.Cliente.ObtenerPorIdAsync(clienteId);

            if (clienteDto is null)
            {
                return NotFound(new { Mensaje = "Cliente no encontrado." });
            }

            return Ok(clienteDto);
        }
    }
}
