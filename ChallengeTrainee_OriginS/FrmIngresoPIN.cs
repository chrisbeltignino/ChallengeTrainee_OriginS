using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    public partial class FrmIngresoPIN : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;

        private FrmATM _parentForm;
        private int intentosFallidos = 0;
        private int intentos = 4;
        private System.Windows.Forms.Timer desbloqueoTimer;

        public FrmIngresoPIN(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

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
                if (txtPIN.Text.Length < 4)
                {
                    txtPIN.Text += boton.Text;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string numPIN = txtPIN.Text;

            bool PINValido = _tarjetaService.ValidarPIN(_tarjetaEncontrada, numPIN);

            if (!_tarjetaService.VerificarTarjetaBloqueada(_tarjetaEncontrada.Numero_Tarjeta))
            {
                if (PINValido)
                {
                    _parentForm.OpenChildForm(new FrmOperaciones(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
                    intentosFallidos = 0;
                }
                else
                {
                    intentosFallidos++;
                    intentos--;
                    if (intentosFallidos == 4)
                    {
                        BloquearTarjetaYConfigurarTimerDesbloqueo();
                        MessageBox.Show("Supero el limite de intentos, pruebe mas tarde", "Tarjeta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        intentosFallidos = 0;
                        intentos = 0;
                    }
                    else
                    {
                        MessageBox.Show("El PIN ingresado no es valido. No se puede continuar. Tiene " + intentos + " intentos", "PIN invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("La tarjeta sigue bloqueada, espere 40 segundos para el desbloqueo.", "Tarjeta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPIN.Text = string.Empty;
        }

        private void BloquearTarjetaYConfigurarTimerDesbloqueo()
        {
            _tarjetaService.BloquearTarjeta(_tarjetaEncontrada);

            // Configurar temporizador para desbloquear la tarjeta después de 40 segundos
            desbloqueoTimer = new System.Windows.Forms.Timer(); // 40,000 milisegundos = 40 segundos
            desbloqueoTimer.Interval = 40000; // 40,000 milisegundos = 40 segundos
            desbloqueoTimer.Tick += (sender, e) => DesbloquearTarjetaDespuesDeTimer();
            desbloqueoTimer.Start();
        }

        private void DesbloquearTarjetaDespuesDeTimer()
        {
            _tarjetaService.DesbloquearTarjeta(_tarjetaEncontrada);
            intentosFallidos = 0;
            intentos = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }
    }
}
