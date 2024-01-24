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
        public FrmReporte(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, Operacion operacionRegistrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this._tarjetaEncontrada = tarjetaEncontrada;
            this._operacionRegistrada = operacionRegistrada;

            this.db = db;

            this._parentForm = parentForm;

            lblCodigoOperacion.Text = string.Empty;
            lblCantidadRetirada.Text = string.Empty;
            lblNumTarjeta.Text = string.Empty;
            lblSaldoActual.Text = string.Empty;
            lblFechaOp.Text = string.Empty;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            if (_tarjetaEncontrada != null && _operacionRegistrada != null)
            {
                lblNumTarjeta.Text = FormatearNumeroTarjeta(_tarjetaEncontrada.Numero_Tarjeta);
                lblSaldoActual.Text = $"{_tarjetaEncontrada.Saldo.ToString("C2")}";
                lblFechaOp.Text = _operacionRegistrada.Fecha_Operacion.ToString();
                lblCodigoOperacion.Text = _operacionRegistrada.Codigo_Operacion;
                lblCantidadRetirada.Text = $"{_operacionRegistrada.Cantidad_Retirada.ToString("C2")}";
            }
        }

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
