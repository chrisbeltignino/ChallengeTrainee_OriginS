using ATM.Application.Interfaces;
using Core;

namespace Infrastructure.Services
{
    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository;
        private readonly ITarjetaRepository _tarjetaRepository;

        public OperacionService(IOperacionRepository operacionRepository, ITarjetaRepository tarjetaRepository)
        {
            _operacionRepository = operacionRepository;
            _tarjetaRepository = tarjetaRepository;
        }

        public void RegistrarOperacion(Operacion operacion)
        {
            _operacionRepository.RegistrarOperacion(operacion);
        }

        public Operacion RealizarRetiro(Tarjeta tarjeta, decimal cantidad)
        {
            tarjeta.Saldo -= cantidad;
            _tarjetaRepository.ActualizarTarjeta(tarjeta);

            var operacion = new Operacion
            {
                ID_Tarjeta = tarjeta.ID_Tarjeta,
                Fecha_Operacion = DateTime.Now,
                Codigo_Operacion = "Retiro",
                Cantidad_Retirada = cantidad
            };

            _operacionRepository.RegistrarOperacion(operacion);

            return operacion;
        }

        public bool ValidarSaldoSuficiente(Tarjeta tarjeta, decimal cantidad)
        {
            if (tarjeta != null && tarjeta.Saldo >= cantidad)
            {
                return true; // Hay saldo suficiente
            }
            return false; // No hay saldo suficiente
        }

        public Operacion ObtenerPorId(int id)
        {
            return _operacionRepository.ObtenerPorId(id);
        }

        public bool RealizarBalance(Tarjeta tarjeta)
        {
            var operacion = new Operacion
            {
                ID_Tarjeta = tarjeta.ID_Tarjeta,
                Fecha_Operacion = DateTime.Now,
                Codigo_Operacion = "Balance",
                Cantidad_Retirada = 0
            };

            _operacionRepository.RegistrarOperacion(operacion);

            return true;
        }
    }
}
