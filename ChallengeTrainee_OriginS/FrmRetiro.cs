using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    public partial class FrmRetiro : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;
        Operacion _operacionRegistrada;

        private FrmATM _parentForm;

        /// <summary>
        /// Constructor de la clase FrmRetiro.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        /// <param name="db">Instancia del contexto de la base de datos.</param>
        /// <param name="tarjetaEncontrada">Tarjeta asociada al formulario.</param>
        /// <param name="parentForm">Formulario principal que contiene este formulario como hijo.</param>
        public FrmRetiro(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

            // Inicializar etiquetas y campos de texto con valores predeterminados
            lblSaldo.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            // Asociar el evento NumeroBtn_Click a varios botones numéricos
            btnCero.Click += NumeroBtn_Click;
            btnUno.Click += NumeroBtn_Click;
            btnDos.Click += NumeroBtn_Click;
            btnTres.Click += NumeroBtn_Click;
            btnCuatro.Click += NumeroBtn_Click;
            btnCinco.Click += NumeroBtn_Click;
            btnSeis.Click += NumeroBtn_Click;
            btnSiete.Click += NumeroBtn_Click;
            btnOcho.Click += NumeroBtn_Click;
            btnNueve.Click += NumeroBtn_Click;
        }

        /// <summary>
        /// Manejador de eventos para los botones numéricos.
        /// </summary>
        private void NumeroBtn_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            // Agregar el número presionado al campo de cantidad
            if (char.IsDigit(boton.Text[0]))
            {
                txtCantidad.Text += boton.Text;
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Convertir la cantidad ingresada a un valor numérico
            int numCantidad = Convert.ToInt32(txtCantidad.Text);

            if (numCantidad > 0)
            {
                // Verificar si hay saldo suficiente
                if (_operacionService.ValidarSaldoSuficiente(_tarjetaEncontrada, numCantidad))
                {
                    // Realizar el retiro
                    this.Close();
                    _operacionRegistrada = _operacionService.RealizarRetiro(_tarjetaEncontrada, numCantidad);
                    // Abrir el formulario de reporte en el formulario principal
                    _parentForm.OpenChildForm(new FrmReporte(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _operacionRegistrada, _parentForm));
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error al ingresar el Saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Limpiar.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de cantidad
            txtCantidad.Text = string.Empty;
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se carga el formulario.
        /// </summary>
        private void FrmRetiro_Load(object sender, EventArgs e)
        {
            // Mostrar el saldo actual de la tarjeta
            lblSaldo.Text = $"{_tarjetaEncontrada.Saldo.ToString("C2")}";
        }

        /// <summary>
        /// Manejador de eventos para el botón Salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abrir el formulario de operaciones en el formulario principal
            _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }
    }
}
