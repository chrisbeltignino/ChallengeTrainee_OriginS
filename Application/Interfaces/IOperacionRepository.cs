using Core;

namespace ATM.Application.Interfaces
{
    public interface IOperacionRepository
    {
        void RegistrarOperacion(Operacion operacion);
        Operacion ObtenerPorId(int id);
    }
}
