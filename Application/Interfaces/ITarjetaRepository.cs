using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITarjetaRepository
    {
        Tarjeta ObtenerTarjeta(string numTarjeta);
        public void ActualizarTarjeta(Tarjeta tarjeta);
    }
}
