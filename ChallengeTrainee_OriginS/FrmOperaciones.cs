using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    public partial class FrmOperaciones : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;

        private FrmATM _parentForm;

        /// <summary>
        /// Constructor de la clase FrmOperaciones.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        /// <param name="db">Instancia del contexto de la base de datos.</param>
        /// <param name="tarjetaEncontrada">Tarjeta asociada al formulario.</param>
        /// <param name="parentForm">Formulario principal que contiene este formulario como hijo.</param>
        public FrmOperaciones(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se carga el formulario.
        /// Muestra Nombre y Apellido del cliente asociado a la Tarjeta.
        /// </summary>
        private void FrmOperaciones_Load(object sender, EventArgs e)
        {
            lblCliente.Text = $"{_tarjetaEncontrada.Cliente.Nombre} {_tarjetaEncontrada.Cliente.Apellido}";
        }

        /// <summary>
        /// Manejador de eventos para el botón Salir.
        /// Redirije al formulario Home.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abre el formulario de inicio en el formulario principal.
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }

        /// <summary>
        /// Manejador de eventos para el botón Balance.
        /// Realiza el la operacion Balance y redirije al formulario Balance.
        /// </summary>
        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (_operacionService.RealizarBalance(_tarjetaEncontrada))
            {
                this.Close();
                // Abre el formulario de balance en el formulario principal.
                _parentForm.OpenChildForm(new FrmBalance(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Retiro.
        /// Redirije al formulario Retiro.
        /// </summary>
        private void btnRetiro_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abre el formulario de retiro en el formulario principal.
            _parentForm.OpenChildForm(new FrmRetiro(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }
    }
}
