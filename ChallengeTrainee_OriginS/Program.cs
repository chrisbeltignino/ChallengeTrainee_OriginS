using ATM.Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ChallengeTrainee_OriginS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear el contenedor de IoC
            var container = new Container();

            using (AsyncScopedLifestyle.BeginScope(container))
            {
                container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

                // Registra los servicios y repositorios aquí
                container.Register<ITarjetaService, TarjetaService>();
                container.Register<IOperacionService, OperacionService>();

                container.Register<ITarjetaRepository, TarjetaRepository>();
                container.Register<IOperacionRepository, OperacionRepository>();
                /*
                */

                // Registra DbContext aquí

                container.Register<Db_Connection>(() =>
                {
                    var options = DBConfig.GetOptions();
                    return new Db_Connection(options);
                }, Lifestyle.Scoped);

                //container.Register<Db_Connection>(Lifestyle.Scoped);
                // Registra el Formulario Hijo

                //container.Register<FrmHome>(Lifestyle.Scoped);
                //container.Register<FrmIngresoPIN>();
                //container.Register<FrmOperaciones>();
                //container.Register<FrmReporte>();
                //container.Register<FrmRetiro>();

                // Comprueba si la configuración del contenedor es válida
                container.Verify();

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new FrmATM(
                    container.GetInstance<ITarjetaService>(),
                    container.GetInstance<IOperacionService>()));
            }
        }
    }
}