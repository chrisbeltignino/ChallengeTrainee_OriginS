using Core;

namespace ATM.Application.Interfaces
{
    public interface IOperacionService
    {
        public bool RealizarRetiro(Tarjeta tarjeta, decimal cantidad);
        public bool RealizarBalance(Tarjeta tarjeta);
        public Operacion ObtenerPorId(int id);
    }
}
