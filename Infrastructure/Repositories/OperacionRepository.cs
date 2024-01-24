using ATM.Application.Interfaces;
using Core;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly Db_Connection _dbContext;

        public OperacionRepository(Db_Connection dbContext)
        {
            _dbContext = dbContext;
        }

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

        public Operacion ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Operaciones.FirstOrDefault(c => c.ID_Operacion == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Operacion por ID: " + ex.Message, ex);
            }
        }
    }
}
