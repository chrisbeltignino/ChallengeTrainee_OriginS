using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Entidad que representa una tarjeta en el sistema.
    /// </summary>
    [Table("Tarjetas")]
    public class Tarjeta
    {
        [Key]
        public int ID_Tarjeta { get; set; }
        public int ID_Cliente { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string PIN { get; set; }
        public bool Bloqueada { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        [ForeignKey("ID_Cliente")]
        public virtual Cliente Cliente { get; set; }
        public ICollection<Operacion> Operaciones { get; set; }

        /*
        public Tarjeta() 
        {
            Numero_Tarjeta = string.Empty;
            PIN = string.Empty;
            Cliente = new Cliente();
            Operaciones = new List<Operacion>();
        }*/
    }
}
