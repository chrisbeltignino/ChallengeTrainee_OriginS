using ATM.Application.Interfaces;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool ValidarPIN(Tarjeta tarjeta, string pinIngresado)
        {
            return tarjeta != null && !tarjeta.Bloqueada && tarjeta.PIN == pinIngresado;
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
