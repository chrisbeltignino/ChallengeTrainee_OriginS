﻿using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    /// <summary>
    /// Formulario Hijo que representa la pantalla de inicio del cajero automático.
    /// </summary>
    public partial class FrmHome : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        private FrmATM _parentForm;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmHome"/>.
        /// </summary>
        /// <param name="tarjetaService">Servicio para operaciones relacionadas con tarjetas.</param>
        /// <param name="operacionService">Servicio para operaciones generales.</param>
        /// <param name="db">Conexión a la base de datos.</param>
        /// <param name="parentForm">Formulario principal del cajero automático.</param>
        public FrmHome(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;

            this._parentForm = parentForm;

            // Asociar el evento NumeroBtn_Click a los botones numéricos
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
        /// Agrega el número al cuadro de texto de la tarjeta y formatea la entrada.
        /// </summary>
        private void NumeroBtn_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (char.IsDigit(boton.Text[0]) && txtTarjeta.Text.Length < 19)
            {
                // Elimina los guiones existentes antes de agregar uno nuevo
                string numeroActual = txtTarjeta.Text.Replace("-", "");

                // Si el texto no está vacío y la longitud es divisible por 4, agrega un guion
                if (numeroActual.Length > 0 && numeroActual.Length % 4 == 0)
                {
                    txtTarjeta.Text += "-";
                }

                if (txtTarjeta.Text.Length < 19)
                {
                    txtTarjeta.Text += boton.Text;
                }
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Limpiar.
        /// Limpia el cuadro de texto de la tarjeta.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTarjeta.Text = string.Empty;
        }

        /// <summary>
        /// Manejador de eventos para el botón Aceptar.
        /// Valida la tarjeta ingresada y abre el formulario de ingreso de PIN si es válida.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string numeroTarjeta = txtTarjeta.Text.Replace("-", "");

            Tarjeta tarjetaEncontrada = _tarjetaService.ObtenerTarjetaPorNumero(numeroTarjeta);

            if (numeroTarjeta.Length == 16)
            {
                if (tarjetaEncontrada != null)
                {
                    bool tarjetaBloqueada = _tarjetaService.VerificarTarjetaBloqueada(numeroTarjeta);

                    if (!tarjetaBloqueada)
                    {
                        _parentForm.OpenChildForm(new FrmIngresoPIN(_tarjetaService, _operacionService, db, tarjetaEncontrada, _parentForm));
                    }
                    else
                    {
                        MessageBox.Show("La tarjeta está bloqueada. No se puede continuar.", "Tarjeta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La tarjeta no fue encontrada en la base de datos.", "Tarjeta No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La tarjeta debe contener 16 números.", "Tarjeta Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón Borrar.
        /// Elimina el último carácter del cuadro de texto de la tarjeta.
        /// </summary>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay caracteres en el cuadro de texto
            if (txtTarjeta.Text.Length > 0)
            {
                // Eliminar el último carácter del cuadro de texto
                txtTarjeta.Text = txtTarjeta.Text.Substring(0, txtTarjeta.Text.Length - 1);
            }
        }
    }
}
