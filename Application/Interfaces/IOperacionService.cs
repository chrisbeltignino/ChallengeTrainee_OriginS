using Core;

namespace ATM.Application.Interfaces
{
    public interface IOperacionService
    {
        public Operacion RealizarRetiro(Tarjeta tarjeta, decimal cantidad);
        bool ValidarSaldoSuficiente(Tarjeta tarjeta, decimal cantidad);
        public bool RealizarBalance(Tarjeta tarjeta);
        public Operacion ObtenerPorId(int id);
    }
}
