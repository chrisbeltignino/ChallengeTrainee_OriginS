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

        public FrmBalance(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

            lblNombre.Text = string.Empty;
            lblApellido.Text = string.Empty;
            lblDNI.Text = string.Empty;
            lblNumTarjeta.Text = string.Empty;
            lblSaldo.Text = string.Empty;
            lblFechaVcto.Text = string.Empty;
        }

        private void FrmBalance_Load(object sender, EventArgs e)
        {
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

        private string FormatearNumeroTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length == 16)
            {
                return string.Format("{0:####-####-####-####}", long.Parse(numeroTarjeta));
            }

            return numeroTarjeta;
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
    }
}
