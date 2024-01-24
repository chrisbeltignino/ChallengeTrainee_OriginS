using Core;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace TestATM
{
    public class OperacionServiceTests
    {
        /*
        [Fact]
        public void TestDatabaseConnection()
        {
            // Configuración
            var options = DBConfig.GetOptions();

            // Ejecución
            using (var context = new Db_Connection(options))
            {
                // Verificación
                Assert.True(context.Database.CanConnect());
            }
        }

        [Fact]
        public void TestRegistrarOperacion()
        {
            // Configuración
            var options = DBConfig.GetOptions();
            var dbContext = new Db_Connection(options);
            var tarjetaRepository = new TarjetaRepository(dbContext);
            var operacionRepository = new OperacionRepository(dbContext);
            var operacionService = new OperacionService(operacionRepository, tarjetaRepository);

            // Obtengo una tarjeta existente
            var numeroTarjetaExistente = "1111111111111111";
            var tarjetaExistente = tarjetaRepository.ObtenerTarjeta(numeroTarjetaExistente);

            // Asegurarse de que la tarjeta exista para la prueba
            Assert.NotNull(tarjetaExistente);

            // Ejecución
            var operacion = new Operacion
            {
                ID_Tarjeta = tarjetaExistente.ID_Tarjeta,
                Fecha_Operacion = DateTime.Now, // Usa ToUniversalTime
                Codigo_Operacion = "Retiro",
                Cantidad_Retirada = 100.00m
            };

            operacionService.RegistrarOperacion(operacion);

            // Verificación

            var operacionRegistrada = operacionRepository.ObtenerPorId(operacion.ID_Operacion);
            Assert.NotNull(operacionRegistrada);
            Assert.Equal(operacion.Cantidad_Retirada, operacionRegistrada.Cantidad_Retirada);
        }

        [Fact]
        public void TestRealizarRetiro()
        {
            // Configuración
            var options = DBConfig.GetOptions();
            var dbContext = new Db_Connection(options);
            var tarjetaRepository = new TarjetaRepository(dbContext);
            var operacionRepository = new OperacionRepository(dbContext);
            var operacionService = new OperacionService(operacionRepository, tarjetaRepository);

            // Obtengo una tarjeta existente
            var numeroTarjetaExistente = "1111111111111111";
            var tarjetaExistente = tarjetaRepository.ObtenerTarjeta(numeroTarjetaExistente);

            // Asegurarse de que la tarjeta exista para la prueba
            Assert.NotNull(tarjetaExistente);

            // Ejecución
            var resultado = operacionService.RealizarRetiro(tarjetaExistente, 50.0m);

            // Verificación
            Assert.True(resultado);
        }

        [Fact]
        public void TestObtenerBalanceTarjeta()
        {
            // Configuración
            var options = DBConfig.GetOptions();
            var dbContext = new Db_Connection(options);
            var tarjetaRepository = new TarjetaRepository(dbContext);
            var operacionRepository = new OperacionRepository(dbContext);
            var operacionService = new OperacionService(operacionRepository, tarjetaRepository);

            // Obtener una tarjeta existente (puedes cambiar el número de tarjeta según tu base de datos)
            var numeroTarjetaExistente = "1111111111111111";
            var tarjetaExistente = tarjetaRepository.ObtenerTarjeta(numeroTarjetaExistente);

            // Asegurarse de que la tarjeta exista para la prueba
            Assert.NotNull(tarjetaExistente);

            // Ejecución
            var balance = operacionService.ObtenerInformacionBalance(tarjetaExistente.Numero_Tarjeta);

            // Verificación
            Assert.NotNull(balance);
        }*/
        /*
        [Fact]
        public void TestValidarPIN()
        {
            // Configuración
            var options = DBConfig.GetOptions();
            var dbContext = new Db_Connection(options);
            var tarjetaRepository = new TarjetaRepository(dbContext);
            var operacionRepository = new OperacionRepository(dbContext);
            var operacionService = new OperacionService(operacionRepository, tarjetaRepository);

            // Obtener una tarjeta existente (puedes cambiar el número de tarjeta según tu base de datos)
            var numeroTarjetaExistente = "1111111111111111";
            var tarjetaExistente = tarjetaRepository.ObtenerTarjeta(numeroTarjetaExistente);

            // Asegurarse de que la tarjeta exista para la prueba
            Assert.NotNull(tarjetaExistente);

            // PIN correcto
            var pinCorrecto = "1234";
            var resultadoCorrecto = operacionService.ValidarPIN(tarjetaExistente, pinCorrecto);
            Assert.True(resultadoCorrecto);

            // PIN incorrecto
            var pinIncorrecto = "0000";
            var resultadoIncorrecto = operacionService.ValidarPIN(tarjetaExistente, pinIncorrecto);
            Assert.False(resultadoIncorrecto);
        }
        */
    }
}