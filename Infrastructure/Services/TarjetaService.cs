using ATM.Application.Interfaces;
using Core;

namespace Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de tarjetas.
    /// </summary>
    public class TarjetaService : ITarjetaService
    {
        private readonly ITarjetaRepository _tarjetaRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de tarjetas.
        /// </summary>
        /// <param name="tarjetaRepository">El repositorio de tarjetas.</param>
        public TarjetaService(ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository ?? throw new ArgumentNullException(nameof(tarjetaRepository));
        }

        /// <summary>
        /// Obtiene una tarjeta por su número.
        /// </summary>
        /// <param name="numTarjeta">El número de tarjeta a ser obtenido.</param>
        /// <returns>La tarjeta correspondiente al número proporcionado.</returns>
        public Tarjeta ObtenerTarjetaPorNumero(string numTarjeta)
        {
            return _tarjetaRepository.ObtenerTarjeta(numTarjeta);
        }

        /// <summary>
        /// Obtiene una tarjeta por su objeto.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al objeto proporcionado.</returns>
        public Tarjeta ObtenerTarjeta(Tarjeta tarjeta)
        {
            return _tarjetaRepository.ObtenerTarjeta(tarjeta);
        }

        /// <summary>
        /// Valida el PIN de una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta cuyo PIN se va a validar.</param>
        /// <param name="pinIngresado">El PIN ingresado por el usuario.</param>
        /// <returns>True si el PIN es válido, False en caso contrario.</returns>
        public bool ValidarPIN(Tarjeta tarjeta, string pinIngresado)
        {
            return tarjeta != null && tarjeta.PIN == pinIngresado;
        }

        /// <summary>
        /// Verifica si una tarjeta está bloqueada.
        /// </summary>
        /// <param name="numeroTarjeta">El número de tarjeta a ser verificado.</param>
        /// <returns>True si la tarjeta está bloqueada, False en caso contrario.</returns>
        public bool VerificarTarjetaBloqueada(string numeroTarjeta)
        {
            Tarjeta tarjeta = _tarjetaRepository.ObtenerTarjeta(numeroTarjeta);

            return tarjeta != null && tarjeta.Bloqueada;
        }

        /// <summary>
        /// Bloquea una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser bloqueada.</param>
        /// <returns>True si la tarjeta fue bloqueada con éxito, False en caso contrario.</returns>
        public bool BloquearTarjeta(Tarjeta tarjeta)
        {
            if (tarjeta != null)
            {
                tarjeta.Bloqueada = true;
                _tarjetaRepository.ActualizarTarjeta(tarjeta);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Desbloquea una tarjeta.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser desbloqueada.</param>
        /// <returns>True si la tarjeta fue desbloqueada con éxito, False en caso contrario.</returns>
        public bool DesbloquearTarjeta(Tarjeta tarjeta)
        {
            if (tarjeta != null)
            {
                tarjeta.Bloqueada = false;
                _tarjetaRepository.ActualizarTarjeta(tarjeta);
                return true;
            }
            return false;
        }
    }
}
