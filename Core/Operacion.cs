using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Operacion
    {
        public int ID_Operacion { get; set; }
        public int ID_Tarjeta { get; set; }
        public DateTime Fecha_Operacion { get; set; }
        public string Codigo_Operacion { get; set; }
        public decimal Cantidad_Retirada { get; set; }
    }
}
