using Core;

namespace ATM.Application.Interfaces
{
    public interface ITarjetaRepository
    {
        Tarjeta ObtenerTarjeta(string numTarjeta);
        Tarjeta ObtenerTarjeta(Tarjeta tarjeta);
        void ActualizarTarjeta(Tarjeta tarjeta);
        Tarjeta ObtenerPorId(int id);
    }
}
