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

        public FrmRetiro(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

            lblSaldo.Text = string.Empty;
            txtCantidad.Text = string.Empty;

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

        private void NumeroBtn_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (char.IsDigit(boton.Text[0]))
            {
                txtCantidad.Text += boton.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int numCantidad = Convert.ToInt32(txtCantidad.Text);

            if (numCantidad > 0)
            {
                if (_operacionService.ValidarSaldoSuficiente(_tarjetaEncontrada, numCantidad))
                {
                    this.Close();
                    _operacionRegistrada = _operacionService.RealizarRetiro(_tarjetaEncontrada, numCantidad);
                    _parentForm.OpenChildForm(new FrmReporte(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _operacionRegistrada, _parentForm));
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad valida.", "Error al ingresar el Saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = string.Empty;
        }

        private void FrmRetiro_Load(object sender, EventArgs e)
        {
            lblSaldo.Text = $"{_tarjetaEncontrada.Saldo.ToString("C2")}";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }
    }
}
