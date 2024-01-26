using Core;

namespace ATM.Application.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con el servicio de operaciones.
    /// </summary>
    public interface IOperacionService
    {
        /// <summary>
        /// Realiza un retiro de dinero de la tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta asociada a la operación.</param>
        /// <param name="cantidad">La cantidad a retirar.</param>
        /// <returns>La operación de retiro realizada.</returns>
        public Operacion RealizarRetiro(Tarjeta tarjeta, decimal cantidad);

        /// <summary>
        /// Valida si hay saldo suficiente en la tarjeta para realizar un retiro.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser validada.</param>
        /// <param name="cantidad">La cantidad a retirar.</param>
        /// <returns>True si hay saldo suficiente; de lo contrario, false.</returns>
        bool ValidarSaldoSuficiente(Tarjeta tarjeta, decimal cantidad);

        /// <summary>
        /// Realiza una operación de balance en la tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta asociada a la operación.</param>
        /// <returns>True si la operación de balance fue exitosa; de lo contrario, false.</returns>
        public bool RealizarBalance(Tarjeta tarjeta);

        /// <summary>
        /// Obtiene una operación por su ID.
        /// </summary>
        /// <param name="id">El ID de la operación a ser obtenida.</param>
        /// <returns>La operación correspondiente al ID proporcionado.</returns>
        public Operacion ObtenerPorId(int id);
    }
}
