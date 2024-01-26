using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    public partial class FrmReporte : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;
        Operacion _operacionRegistrada;

        private FrmATM _parentForm;

        /// <summary>
        /// Constructor de la clase FrmReporte.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        /// <param name="db">Instancia del contexto de la base de datos.</param>
        /// <param name="tarjetaEncontrada">Tarjeta asociada al formulario.</param>
        /// <param name="operacionRegistrada">Operación asociada al formulario.</param>
        /// <param name="parentForm">Formulario principal que contiene este formulario como hijo.</param>
        public FrmReporte(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, Operacion operacionRegistrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this._tarjetaEncontrada = tarjetaEncontrada;
            this._operacionRegistrada = operacionRegistrada;

            this.db = db;

            this._parentForm = parentForm;

            // Inicializar etiquetas con valores predeterminados
            lblCodigoOperacion.Text = string.Empty;
            lblCantidadRetirada.Text = string.Empty;
            lblNumTarjeta.Text = string.Empty;
            lblSaldoActual.Text = string.Empty;
            lblFechaOp.Text = string.Empty;
        }

        /// <summary>
        /// Manejador de eventos para el botón Atras.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abrir el formulario de operaciones en el formulario principal
            _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }

        /// <summary>
        /// Manejador de eventos para el botón Salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abrir el formulario principal
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se carga el formulario.
        /// </summary>
        private void FrmReporte_Load(object sender, EventArgs e)
        {
            // Mostrar la información de la tarjeta y la operación
            if (_tarjetaEncontrada != null && _operacionRegistrada != null)
            {
                lblNumTarjeta.Text = FormatearNumeroTarjeta(_tarjetaEncontrada.Numero_Tarjeta);
                lblSaldoActual.Text = $"{_tarjetaEncontrada.Saldo.ToString("C2")}";
                lblFechaOp.Text = _operacionRegistrada.Fecha_Operacion.ToString();
                lblCodigoOperacion.Text = _operacionRegistrada.Codigo_Operacion;
                lblCantidadRetirada.Text = $"{_operacionRegistrada.Cantidad_Retirada.ToString("C2")}";
            }
        }

        /// <summary>
        /// Formatea el número de tarjeta para mostrarlo de manera legible.
        /// </summary>
        private string FormatearNumeroTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length == 16)
            {
                return string.Format("{0:####-####-####-####}", long.Parse(numeroTarjeta));
            }

            return numeroTarjeta;
        }
    }
}
