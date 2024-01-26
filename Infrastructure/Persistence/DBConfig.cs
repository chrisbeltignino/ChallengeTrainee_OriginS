using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Clase estática para configurar las opciones de DbContext.
    /// </summary>
    public static class DBConfig
    {
        /// <summary>
        /// Obtiene las opciones de DbContext para la conexión a la base de datos.
        /// </summary>
        /// <returns>Las opciones de DbContext configuradas.</returns>
        public static DbContextOptions<Db_Connection> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<Db_Connection>();
            builder.UseSqlServer("Data Source=.; Initial Catalog=BD_ORIGIN_S; Integrated Security=True; TrustServerCertificate=True");
            return builder.Options;
        }
    }
}
