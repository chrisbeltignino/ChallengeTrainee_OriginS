using SimpleInjector.Lifestyles;
using SimpleInjector;
using Infrastructure.Services;
using Infrastructure.Repositories;
using Infrastructure.Persistence;
using ATM.Application.Interfaces;

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

                // Registra tus servicios y repositorios aquí
                container.Register<ITarjetaService, TarjetaService>();
                container.Register<IOperacionService, OperacionService>();

                container.Register<ITarjetaRepository, TarjetaRepository>();
                container.Register<IOperacionRepository, OperacionRepository>();

                // Registra tu DbContext aquí
                container.Register<Db_Connection>(Lifestyle.Scoped);

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
                Application.Run(new FrmHome());
            }
        }
    }
}