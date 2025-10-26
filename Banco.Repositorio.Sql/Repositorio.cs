using Banco.Core.Repositorio.Interfaces;

namespace Banco.Repositorio.Sql
{
    internal class Repositorio : IRepositorio
    {
        public IAhorroRepositorio Ahorro { get; }

        public IClienteRepositorio Cliente { get; }


        public Repositorio(
            IAhorroRepositorio ahorroRepositorio,
            IClienteRepositorio clienteRepositorio
        )
        {
            Ahorro = ahorroRepositorio;
            Cliente = clienteRepositorio;
        }
    }
}
