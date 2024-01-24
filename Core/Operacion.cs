using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("Operaciones")]
    public class Operacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Operacion { get; set; }
        public int ID_Tarjeta { get; set; }
        public DateTime? Fecha_Operacion { get; set; }
        public string Codigo_Operacion { get; set; }
        public decimal Cantidad_Retirada { get; set; }
        [ForeignKey("ID_Tarjeta")]
        public virtual Tarjeta Tarjeta { get; set; }
    }
}
