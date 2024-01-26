using Core;

namespace ATM.Application.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con el repositorio de operaciones.
    /// </summary>
    public interface IOperacionRepository
    {
        /// <summary>
        /// Registra una nueva operación en el repositorio.
        /// </summary>
        /// <param name="operacion">La operación a ser registrada.</param>
        void RegistrarOperacion(Operacion operacion);

        /// <summary>
        /// Obtiene una operación por su ID.
        /// </summary>
        /// <param name="id">El ID de la operación a ser obtenida.</param>
        /// <returns>La operación correspondiente al ID proporcionado.</returns>
        Operacion ObtenerPorId(int id);
    }
}
