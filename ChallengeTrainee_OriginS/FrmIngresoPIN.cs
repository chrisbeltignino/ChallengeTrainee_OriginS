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

        /// <summary>
        /// Constructor de la clase FrmIngresoPIN.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        /// <param name="db">Instancia del contexto de la base de datos.</param>
        /// <param name="tarjetaEncontrada">Tarjeta asociada al formulario.</param>
        /// <param name="parentForm">Formulario principal que contiene este formulario como hijo.</param>
        public FrmIngresoPIN(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;

            // Asigna el método NumeroBtn_Click a los eventos de los botones numéricos.
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
        /// Agrega el número al cuadro de texto del PIN.
        /// </summary>
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

        /// <summary>
        /// Manejador de eventos para el botón Aceptar.
        /// Realiza la validación del PIN ingresado y abre el formulario de Operaciones si es válido.
        /// Caso contrario se bloqueara la tarjeta por 40seg.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string numPIN = txtPIN.Text;

            if (!_tarjetaService.VerificarTarjetaBloqueada(_tarjetaEncontrada.Numero_Tarjeta))
            {
                bool PINValido = _tarjetaService.ValidarPIN(_tarjetaEncontrada, numPIN);

                if (PINValido)
                {
                    // Abre el formulario de operaciones en el formulario principal.
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
                        MessageBox.Show("Supero el límite de intentos, pruebe más tarde", "Tarjeta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        intentosFallidos = 0;
                        intentos = 0;
                    }
                    else
                    {
                        MessageBox.Show("El PIN ingresado no es válido. No se puede continuar. Tiene " + intentos + " intentos", "PIN inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("La tarjeta sigue bloqueada, espere 40 segundos para el desbloqueo.", "Tarjeta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Limpiar.
        /// Limpia el cuadro de texto del PIN.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPIN.Text = string.Empty;
        }

        /// <summary>
        /// Bloquea la tarjeta y configura un temporizador para desbloquearla después de 40 segundos.
        /// </summary>
        private void BloquearTarjetaYConfigurarTimerDesbloqueo()
        {
            _tarjetaService.BloquearTarjeta(_tarjetaEncontrada);

            // Configura temporizador para desbloquear la tarjeta después de 40 segundos.
            desbloqueoTimer = new System.Windows.Forms.Timer();                                 // 40,000 milisegundos = 40 segundos
            desbloqueoTimer.Interval = 40000;                                                   // 40,000 milisegundos = 40 segundos
            desbloqueoTimer.Tick += (sender, e) => DesbloquearTarjetaDespuésDeTimer();
            desbloqueoTimer.Start();
        }

        /// <summary>
        /// Desbloquea la tarjeta después de que el temporizador haya transcurrido.
        /// </summary>
        private void DesbloquearTarjetaDespuésDeTimer()
        {
            _tarjetaService.DesbloquearTarjeta(_tarjetaEncontrada);
            intentosFallidos = 0;
            intentos = 0;
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
        /// Manejador de eventos para el botón Borrar.
        /// Elimina el último carácter del cuadro de texto de la tarjeta.
        /// </summary>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay caracteres en el cuadro de texto
            if (txtPIN.Text.Length > 0)
            {
                // Eliminar el último carácter del cuadro de texto
                txtPIN.Text = txtPIN.Text.Substring(0, txtPIN.Text.Length - 1);
            }
        }
    }
}
