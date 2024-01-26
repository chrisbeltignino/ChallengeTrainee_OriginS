using ATM.Application.Interfaces;
using Core;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de tarjetas.
    /// </summary>
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly Db_Connection _dbContext;

        /// <summary>
        /// Constructor que recibe el contexto de la base de datos.
        /// </summary>
        /// <param name="dbContext">El contexto de la base de datos.</param>
        public TarjetaRepository(Db_Connection dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Obtiene una tarjeta por su número.
        /// </summary>
        /// <param name="numTarjeta">El número de tarjeta a ser obtenido.</param>
        /// <returns>La tarjeta correspondiente al número proporcionado.</returns>
        public Tarjeta ObtenerTarjeta(string numTarjeta)
        {
            try
            {
                return _dbContext.Tarjetas
                    .Include(t => t.Cliente)
                    .Include(t => t.Operaciones)
                    .FirstOrDefault(t => t.Numero_Tarjeta == numTarjeta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Tarjeta: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene una tarjeta por su objeto.
        /// </summary>
        /// <param name="tarjeta">La tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al objeto proporcionado.</returns>
        public Tarjeta ObtenerTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return _dbContext.Tarjetas
                    .Include(t => t.Cliente)
                    .Include(t => t.Operaciones)
                    .FirstOrDefault(t => t.ID_Tarjeta == tarjeta.ID_Tarjeta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener al Tarjeta: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza la información de una tarjeta en la base de datos.
        /// </summary>
        /// <param name="tarjeta">La tarjeta con la información actualizada.</param>
        public void ActualizarTarjeta(Tarjeta tarjeta)
        {
            _dbContext.Entry(tarjeta).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Obtiene una tarjeta por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarjeta a ser obtenida.</param>
        /// <returns>La tarjeta correspondiente al ID proporcionado.</returns>
        public Tarjeta ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Tarjetas.FirstOrDefault(c => c.ID_Tarjeta == id) ?? new Tarjeta();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Tarjeta por ID: " + ex.Message, ex);
            }
        }
    }
}
