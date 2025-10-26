using Banco.Core.Interfaces;

namespace Banco.ReglasDeNegocio.Reglas
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAhorroReglasDeNegocio Ahorro { get; }

        public IClienteReglasDeNEgocio Cliente { get; }

        public IEstadoReglasDeNegocio Estado { get; }

        public UnitOfWork(
            IAhorroReglasDeNegocio ahorroReglasDeNegocio,
            IClienteReglasDeNEgocio clienteReglasDeNegocio,
            IEstadoReglasDeNegocio estadoReglasDeNegocio)
        {
            Ahorro = ahorroReglasDeNegocio;
            Cliente = clienteReglasDeNegocio;
            Estado = estadoReglasDeNegocio;
        }
    }
}
