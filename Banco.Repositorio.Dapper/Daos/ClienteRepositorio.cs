using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Banco.Repositorio.Dapper.Daos
{
    public class ClienteRepositorio(IConfiguration configuration) : IClienteRepositorio
    {
        public readonly string _cadenaDeConexion = configuration.GetConnectionString("Banco");

        public async Task<int> AgregarAsync(ClienteEntidad entidad)
        {
            string query;

            query = "INSERT INTO Cliente (EncodedKey, PrimerApellido, SegundoApellido, Correo, Nombre, Telefono, FechaDeNacimiento, EstadoDeNacimiento, FechaDeRegistro, EstaActivo) VALUES(@EncodedKey, @PrimerApellido, @SegundoApellido, @Correo, @Nombre, @Telefono, @FechaDeNacimiento, @EstadoDeNacimiento, @FechaDeRegistro, @EstaActivo);";

            using var db = new SqlConnection(_cadenaDeConexion);
            entidad.Id = (await db.QueryAsync<int>(query, entidad)).FirstOrDefault();

            return entidad.Id;
        }

        public Task<ClienteEntidad> ObtenerAsync(string clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteEntidad> ObtenerPorCorreoAsync(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteEntidad> ObtenerPorCurpAsync(string curp)
        {
            throw new NotImplementedException();
        }
    }
}
