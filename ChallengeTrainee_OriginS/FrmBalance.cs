using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmBalance : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;

        private FrmATM _parentForm;

        /// <summary>
        /// Constructor de la clase FrmBalance.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        /// <param name="db">Instancia del contexto de la base de datos.</param>
        /// <param name="tarjetaEncontrada">Tarjeta asociada al formulario.</param>
        /// <param name="parentForm">Formulario principal que contiene este formulario como hijo.</param>
        public FrmBalance(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

            // Inicializar etiquetas con valores predeterminados
            lblNombre.Text = string.Empty;
            lblApellido.Text = string.Empty;
            lblDNI.Text = string.Empty;
            lblNumTarjeta.Text = string.Empty;
            lblSaldo.Text = string.Empty;
            lblFechaVcto.Text = string.Empty;
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se carga el formulario.
        /// </summary>
        private void FrmBalance_Load(object sender, EventArgs e)
        {
            // Mostrar información de la tarjeta si está disponible
            if (_tarjetaEncontrada != null)
            {
                lblNombre.Text = _tarjetaEncontrada.Cliente.Nombre;
                lblApellido.Text = _tarjetaEncontrada.Cliente.Apellido;
                lblDNI.Text = _tarjetaEncontrada.Cliente.DNI.ToString();
                lblNumTarjeta.Text = FormatearNumeroTarjeta(_tarjetaEncontrada.Numero_Tarjeta);
                lblSaldo.Text = $"{_tarjetaEncontrada.Saldo.ToString("C2")}";
                lblFechaVcto.Text = _tarjetaEncontrada.Fecha_Vencimiento.ToString("MM/yyyy");
            }
        }

        /// <summary>
        /// Formatea el número de tarjeta para mostrarlo con espacios.
        /// </summary>
        /// <param name="numeroTarjeta">Número de tarjeta a formatear.</param>
        /// <returns>Número de tarjeta formateado.</returns>
        private string FormatearNumeroTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length == 16)
            {
                return string.Format("{0:####-####-####-####}", long.Parse(numeroTarjeta));
            }

            return numeroTarjeta;
        }

        /// <summary>
        /// Manejador de eventos para el botón Atrás.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abre el formulario de operaciones en el formulario principal.
            _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }

        /// <summary>
        /// Manejador de eventos para el botón Salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            // Abre el formulario de inicio en el formulario principal.
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }
    }
}
