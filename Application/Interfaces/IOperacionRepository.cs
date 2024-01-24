using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application.Interfaces
{
    public interface IOperacionRepository
    {
        void RegistrarOperacion(Operacion operacion);
        Operacion ObtenerPorId(int id);
    }
}
