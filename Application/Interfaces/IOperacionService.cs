using Core;

namespace ATM.Application.Interfaces
{
    public interface IOperacionService
    {
        public bool RealizarRetiro(Tarjeta tarjeta, decimal cantidad);
        public Operacion ObtenerPorId(int id);
        public Tarjeta ObtenerInformacionBalance(Tarjeta tarjeta);
    }
}
