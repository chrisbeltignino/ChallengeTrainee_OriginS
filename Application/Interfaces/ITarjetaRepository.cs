using Core;

namespace ATM.Application.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con el repositorio de tarjetas.
    /// </summary>
    public interface ITarjetaRepository
    {
        /// <summary>
        /// Obtiene una tarjeta por su número.
        /// </summary>
        /// <param name="numTarjeta">El número de la tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al número proporcionado.</returns>
        Tarjeta ObtenerTarjeta(string numTarjeta);

        /// <summary>
        /// Obtiene una tarjeta por su entidad tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente a la entidad tarjeta proporcionada.</returns>
        Tarjeta ObtenerTarjeta(Tarjeta tarjeta);

        /// <summary>
        /// Actualiza la información de una tarjeta en el repositorio.
        /// </summary>
        /// <param name="tarjeta">La tarjeta con la información actualizada.</param>
        void ActualizarTarjeta(Tarjeta tarjeta);

        /// <summary>
        /// Obtiene una tarjeta por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al ID proporcionado.</returns>
        Tarjeta ObtenerPorId(int id);
    }
}
