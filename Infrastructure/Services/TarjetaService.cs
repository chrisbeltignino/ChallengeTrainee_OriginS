using ATM.Application.Interfaces;
using Core;

namespace Infrastructure.Services
{
    public class TarjetaService : ITarjetaService
    {
        private readonly ITarjetaRepository _tarjetaRepository;

        public TarjetaService(ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository;
        }

        public Tarjeta ObtenerTarjetaPorNumero(string numTarjeta)
        {
            return _tarjetaRepository.ObtenerTarjeta(numTarjeta);
        }

        public Tarjeta ObtenerTarjeta(Tarjeta tarjeta)
        {
            return _tarjetaRepository.ObtenerTarjeta(tarjeta);
        }

        public bool ValidarPIN(Tarjeta tarjeta, string pinIngresado)
        {
            return tarjeta != null && tarjeta.PIN == pinIngresado;
        }

        public bool VerificarTarjetaBloqueada(string numeroTarjeta)
        {
            Tarjeta tarjeta = _tarjetaRepository.ObtenerTarjeta(numeroTarjeta);

            return tarjeta != null && tarjeta.Bloqueada;
        }

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
