using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application.Interfaces
{
    public interface ITarjetaService
    {
        public Tarjeta ObtenerTarjetaPorNumero(string numTarjeta);
        public bool ValidarPIN(Tarjeta tarjeta, string pinIngresado);
        public bool BloquearTarjeta(Tarjeta tarjeta);
        public bool DesbloquearTarjeta(Tarjeta tarjeta);
    }
}
