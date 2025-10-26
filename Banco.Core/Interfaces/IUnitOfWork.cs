namespace Banco.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IAhorroReglasDeNegocio Ahorro { get;  }

        public IClienteReglasDeNEgocio Cliente { get;  }

        public IEstadoReglasDeNegocio Estado { get; }
    }
}
