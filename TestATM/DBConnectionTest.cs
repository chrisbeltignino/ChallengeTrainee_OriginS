using Infrastructure.Persistence;

namespace TestATM
{
    public class DBConnectionTest
    {
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
    }
}