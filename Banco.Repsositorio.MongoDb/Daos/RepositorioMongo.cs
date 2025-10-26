using Banco.Core.Repositorio.Interfaces;

namespace Banco.Repsositorio.MongoDb.Daos
{
    internal class RepositorioMongo: IRepositorio
    {
        public IAhorroRepositorio Ahorro { get; }

        public IClienteRepositorio Cliente { get; }


        public RepositorioMongo(
            IAhorroRepositorio ahorroRepositorio,
            IClienteRepositorio clienteRepositorio
        )
        {
            Ahorro = ahorroRepositorio;
            Cliente = clienteRepositorio;
        }
    }
}
