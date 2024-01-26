using Core;

namespace ATM.Application.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con el servicio de tarjetas.
    /// </summary>
    public interface ITarjetaService
    {
        /// <summary>
        /// Obtiene una tarjeta por su número.
        /// </summary>
        /// <param name="numTarjeta">El número de la tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al número proporcionado.</returns>
        Tarjeta ObtenerTarjetaPorNumero(string numTarjeta);

        /// <summary>
        /// Obtiene una tarjeta por su entidad tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente a la entidad tarjeta proporcionada.</returns>
        Tarjeta ObtenerTarjeta(Tarjeta tarjeta);

        /// <summary>
        /// Valida el PIN de una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser validada.</param>
        /// <param name="pinIngresado">El PIN ingresado por el usuario.</param>
        /// <returns>True si el PIN es válido; de lo contrario, false.</returns>
        bool ValidarPIN(Tarjeta tarjeta, string pinIngresado);

        /// <summary>
        /// Verifica si una tarjeta está bloqueada.
        /// </summary>
        /// <param name="numeroTarjeta">El número de la tarjeta a ser verificada.</param>
        /// <returns>True si la tarjeta está bloqueada; de lo contrario, false.</returns>
        bool VerificarTarjetaBloqueada(string numeroTarjeta);

        /// <summary>
        /// Bloquea una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser bloqueada.</param>
        /// <returns>True si la tarjeta fue bloqueada exitosamente; de lo contrario, false.</returns>
        bool BloquearTarjeta(Tarjeta tarjeta);

        /// <summary>
        /// Desbloquea una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser desbloqueada.</param>
        /// <returns>True si la tarjeta fue desbloqueada exitosamente; de lo contrario, false.</returns>
        bool DesbloquearTarjeta(Tarjeta tarjeta);
    }
}
