using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Entidad que representa a un cliente en el sistema.
    /// </summary>
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
