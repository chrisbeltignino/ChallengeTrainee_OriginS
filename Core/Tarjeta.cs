namespace Core
{
    public class Tarjeta
    {
        public int ID_Tarjeta { get; set; }
        public int ID_Cliente { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string PIN { get; set; }
        public bool Bloqueada { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
    }
}
