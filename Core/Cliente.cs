using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
    }
}
