using Banco.Core.Repositorio.Entidades;
using Banco.Core.Repositorio.Interfaces;
using Banco.Repositorio.Sql.DbContexts;

namespace Banco.Repositorio.Sql.Daos
{
    internal class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AgregarAsync(ClienteEntidad entidad)
        {
            _appDbContext.Cliente.Add(entidad);
            await _appDbContext.SaveChangesAsync();

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
