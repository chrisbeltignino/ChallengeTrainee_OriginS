using ATM.Application.Interfaces;
using Core;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de operaciones.
    /// </summary>
    public class OperacionRepository : IOperacionRepository
    {
        private readonly Db_Connection _dbContext;

        /// <summary>
        /// Constructor que recibe el contexto de la base de datos.
        /// </summary>
        /// <param name="dbContext">El contexto de la base de datos.</param>
        public OperacionRepository(Db_Connection dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Registra una nueva operación en la base de datos.
        /// </summary>
        /// <param name="operacion">La operación a ser registrada.</param>
        public void RegistrarOperacion(Operacion operacion)
        {
            try
            {
                if (operacion == null)
                {
                    throw new ArgumentNullException(nameof(operacion));
                }
                _dbContext.Operaciones.Add(operacion);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Registrar la Operacion: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene una operación por su ID.
        /// </summary>
        /// <param name="id">El ID de la operación a ser obtenida.</param>
        /// <returns>La operación correspondiente al ID proporcionado.</returns>
        public Operacion ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Operaciones.FirstOrDefault(c => c.ID_Operacion == id) ?? new Operacion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Operacion por ID: " + ex.Message, ex);
            }
        }
    }
}
