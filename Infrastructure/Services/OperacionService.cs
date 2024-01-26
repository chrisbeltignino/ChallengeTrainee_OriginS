using ATM.Application.Interfaces;
using Core;

namespace Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de operaciones.
    /// </summary>
    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository;
        private readonly ITarjetaRepository _tarjetaRepository;

        /// <summary>
        /// Constructor que recibe los repositorios necesarios.
        /// </summary>
        /// <param name="operacionRepository">El repositorio de operaciones.</param>
        /// <param name="tarjetaRepository">El repositorio de tarjetas.</param>
        public OperacionService(IOperacionRepository operacionRepository, ITarjetaRepository tarjetaRepository)
        {
            _operacionRepository = operacionRepository ?? throw new ArgumentNullException(nameof(operacionRepository));
            _tarjetaRepository = tarjetaRepository ?? throw new ArgumentNullException(nameof(tarjetaRepository));
        }

        /// <summary>
        /// Registra una nueva operación en la base de datos.
        /// </summary>
        /// <param name="operacion">La operación a ser registrada.</param>
        public void RegistrarOperacion(Operacion operacion)
        {
            _operacionRepository.RegistrarOperacion(operacion);
        }

        /// <summary>
        /// Realiza un retiro de una tarjeta y registra la operación correspondiente.
        /// </summary>
        /// <param name="tarjeta">La tarjeta desde la cual se realiza el retiro.</param>
        /// <param name="cantidad">La cantidad a ser retirada.</param>
        /// <returns>La operación de retiro realizada.</returns>
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

        /// <summary>
        /// Valida si una tarjeta tiene saldo suficiente para un retiro.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser validada.</param>
        /// <param name="cantidad">La cantidad a ser retirada.</param>
        /// <returns>True si la tarjeta tiene saldo suficiente, False en caso contrario.</returns>
        public bool ValidarSaldoSuficiente(Tarjeta tarjeta, decimal cantidad)
        {
            return tarjeta != null && tarjeta.Saldo >= cantidad;
        }

        /// <summary>
        /// Obtiene una operación por su ID.
        /// </summary>
        /// <param name="id">El ID de la operación a ser obtenida.</param>
        /// <returns>La operación correspondiente al ID proporcionado.</returns>
        public Operacion ObtenerPorId(int id)
        {
            return _operacionRepository.ObtenerPorId(id);
        }

        /// <summary>
        /// Realiza una operación de balance y la registra.
        /// </summary>
        /// <param name="tarjeta">La tarjeta sobre la cual se realiza el balance.</param>
        /// <returns>True si la operación fue realizada con éxito, False en caso contrario.</returns>
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
