using Banco.Core.Dtos;
using Banco.Core.Interfaces;
using Banco.Core.IServices;
using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Banco.ReglasDeNegocio.Helpers;
using AutorizacionJwtServicio;

namespace Banco.ReglasDeNegocio.Reglas
{
    internal class ClienteReglasDeNegocio(
        IRepositorio repositorio, 
        ICurpService curpService, 
        IEstadoReglasDeNegocio estadoReglasDeNegocio,
        TokenServicio tokenServicio) : IClienteReglasDeNEgocio

    {
        private readonly IRepositorio _repositorio = repositorio;
        private readonly ICurpService _curpService = curpService;
        private readonly IEstadoReglasDeNegocio _estadoReglasDeNegocio = estadoReglasDeNegocio;
        private readonly TokenServicio _tokenServicio = tokenServicio;

        public async Task<IdDto> AgregarAsync(ClienteDtoIn cliente)
        {            
            ClienteEntidad entidad;
            entidad = cliente.ToEntidad();
            entidad.Curp = await ObtenerCurpAsync(cliente);
            entidad.Id = await _repositorio.Cliente.AgregarAsync(entidad);
            await agregarAhorro(entidad);

            return new IdDto { Encodedkey = cliente.EncodedKey, Id = entidad.Id };
        }

        private async Task agregarAhorro(ClienteEntidad entidad)
        {
            AhorroEntidad ahorroEntidad;

            ahorroEntidad = new AhorroEntidad
            {
                Nombre = "Ahorro",
                ClienteEncodedkey = entidad.EncodedKey,
                ClienteId = entidad.Id
            };

            await _repositorio.Ahorro.AgregarAsync(ahorroEntidad);
        }

        private async Task<string> ObtenerCurpAsync(ClienteDtoIn cliente)
        {
            SolicitudDto solicitudDeCurpDtoIn;
            string curp;

            solicitudDeCurpDtoIn = new SolicitudDto
            {
                Nombres = cliente.Nombre,
                primerApellido = cliente.PrimerApellido,
                segundoApellido = cliente.SegundoApellido,
                FechaDeNacimiento = cliente.FechaDeNacimiento,
                Sexo = cliente.Sexo,
                Estado = _estadoReglasDeNegocio.ObtenerPorId(cliente.EstadoDeNacimiento)
            };

            curp = await _curpService.GenerarCurp(solicitudDeCurpDtoIn);
            return curp;
        }        

        public async Task<TokenDto> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion)
        {
            DateTime fechaDeExpiracion = DateTime.Now.AddMinutes(20);

            var cliente = await _repositorio.Cliente.ObtenerPorCorreoAsync(inicioDeSesion.Usuario);

            if(cliente == null)
            {
                return null;
            }

            if(inicioDeSesion.Contraseña != cliente.Contrasenia)
                {
                return null;
            }

            var tokenString = _tokenServicio.ObtenerToken(cliente.Nombre, "Cliente", cliente.Id.ToString(), cliente.Correo, fechaDeExpiracion);

            TokenDto tokenDto = new TokenDto
            {
                Token = tokenString,
                Fecha = fechaDeExpiracion,
                FechaDeExpiracion = fechaDeExpiracion,
                ExpiracionEnMinutos = 20
            };

            return tokenDto;
        }


        public async Task<ClienteDto> ObtenerAsync(ClienteDtoIn cliente)
        {
            ClienteDto clienteDto;
            ClienteEntidad clienteEntidad;

            clienteEntidad = await _repositorio.Cliente.ObtenerAsync(cliente.EncodedKey);
            if(clienteEntidad is null)
            {
                string curp;

                curp = await ObtenerCurpAsync(cliente);
                clienteEntidad = await _repositorio.Cliente.ObtenerPorCurpAsync(curp);
                if(clienteEntidad is null)
                {
                    return null;
                }
            }
            clienteDto = clienteEntidad.ToDto();

            return clienteDto;
        }

        public async Task<ClienteDto> ObtenerPorIdAsync(int clienteId)
        {
            ClienteEntidad clienteEntidad = await _repositorio.Cliente.ObtenerAsync(clienteId.ToString());

            if (clienteEntidad is null)
            {
                return null;
            }

            return clienteEntidad.ToDto();
        }
    }
}
