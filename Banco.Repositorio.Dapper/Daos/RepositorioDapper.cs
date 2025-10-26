using Banco.Core.Repositorio.Interfaces;

namespace Banco.Repositorio.Dapper.Daos
{
    public class RepositorioDapper : IRepositorio
    {
        public IAhorroRepositorio Ahorro { get; }

        public IClienteRepositorio Cliente { get; }


        public RepositorioDapper(
            IAhorroRepositorio ahorroRepositorio,
            IClienteRepositorio clienteRepositorio
        )
        {
            Ahorro = ahorroRepositorio;
            Cliente = clienteRepositorio;
        }
    }
}
