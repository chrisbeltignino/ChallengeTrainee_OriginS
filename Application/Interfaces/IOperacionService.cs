using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperacionService
    {
        public bool RealizarRetiro(Tarjeta tarjeta, decimal cantidad);
        public decimal ObtenerBalance(Tarjeta tarjeta);
    }
}
