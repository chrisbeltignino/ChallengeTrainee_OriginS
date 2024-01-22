using Core;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class Db_Connection : DbContext
    {
        /// <summary>
        /// Constructor que toma las opciones del contexto.
        /// </summary>
        /// <param name="options">Opciones del contexto proporcionadas por el framework.</param>
        public Db_Connection(DbContextOptions<Db_Connection> options) : base(options) { }


        #region ENTIDADES

        /// <summary>
        /// Representa la tabla Cliente en la base de datos.
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }

        /// <summary>
        /// Representa la tabla Tarjeta en la base de datos.
        /// </summary>
        public DbSet<Tarjeta> Tarjetas { get; set; }

        /// <summary>
        /// Representa la tabla Operacion en la base de datos.
        /// </summary>
        public DbSet<Operacion> Operaciones { get; set; }

        #endregion

        /// <summary>
        /// Método llamado al construir el modelo de la base de datos.
        /// Aquí se configuran las relaciones y otras configuraciones específicas del modelo.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de la base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
