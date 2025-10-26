namespace Banco.Core.Repositorio.Interfaces
{
    public interface IRepositorio
    {
        public IAhorroRepositorio Ahorro { get; }
        public IClienteRepositorio Cliente { get;  }
    }
}
