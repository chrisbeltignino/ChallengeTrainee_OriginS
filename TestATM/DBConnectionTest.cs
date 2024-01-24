using Infrastructure.Persistence;

namespace TestATM
{
    public class DBConnectionTest
    {
        [Fact]
        public void TestDatabaseConnection()
        {
            // Configuraci�n
            var options = DBConfig.GetOptions();

            // Ejecuci�n
            using (var context = new Db_Connection(options))
            {
                // Verificaci�n
                Assert.True(context.Database.CanConnect());
            }
        }
    }
}