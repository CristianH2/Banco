using Banco.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Presentacion.Api.Controllers
{
    /// <summary>
    /// Entidades federativas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <summary>
        /// Lista de entidades federativas / estados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult ObtenerEstados()
        {
            return Ok(_unitOfWork.Estado.Obtener());
        }
    }
}
