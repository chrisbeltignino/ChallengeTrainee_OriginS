using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application.Interfaces
{
    public interface IOperacionService
    {
        public bool RealizarRetiro(Tarjeta tarjeta, decimal cantidad);
        public Operacion ObtenerPorId(int id);
        public Tarjeta ObtenerInformacionBalance(string numTarjeta);
    }
}
