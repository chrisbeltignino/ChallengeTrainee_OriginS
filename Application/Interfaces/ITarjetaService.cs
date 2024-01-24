using Core;

namespace ATM.Application.Interfaces
{
    public interface ITarjetaService
    {
        Tarjeta ObtenerTarjetaPorNumero(string numTarjeta);
        Tarjeta ObtenerTarjeta(Tarjeta tarjeta);
        bool ValidarPIN(Tarjeta tarjeta, string pinIngresado);
        bool VerificarTarjetaBloqueada(string numeroTarjeta);
        bool BloquearTarjeta(Tarjeta tarjeta);
        bool DesbloquearTarjeta(Tarjeta tarjeta);
    }
}
