using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application.Interfaces
{
    public interface ITarjetaRepository
    {
        Tarjeta ObtenerTarjeta(string numTarjeta);
        void ActualizarTarjeta(Tarjeta tarjeta);
        Tarjeta ObtenerPorId(int id);
        Tarjeta ObtenerClienteTarjeta(string numTarjeta);
    }
}
