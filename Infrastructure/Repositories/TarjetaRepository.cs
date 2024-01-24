using ATM.Application.Interfaces;
using Core;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly Db_Connection _dbContext;

        public TarjetaRepository(Db_Connection dbContext)
        {
            _dbContext = dbContext;
        }

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

        public Tarjeta ObtenerClienteTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return _dbContext.Tarjetas
                       .Include(t => t.Cliente)
                       .FirstOrDefault(t => t.ID_Tarjeta == tarjeta.ID_Tarjeta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener al Cliente: " + ex.Message, ex);
            }
        }

        public void ActualizarTarjeta(Tarjeta tarjeta)
        {
            _dbContext.Entry(tarjeta).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Tarjeta ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Tarjetas.FirstOrDefault(c => c.ID_Tarjeta == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Tarjeta por ID: " + ex.Message, ex);
            }
        }
    }
}
