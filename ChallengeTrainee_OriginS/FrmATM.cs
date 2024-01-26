using ATM.Application.Interfaces;
using Infrastructure.Persistence;
using Presentation;

namespace ChallengeTrainee_OriginS
{
    public partial class FrmATM : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        private Form currentChildForm;

        /// <summary>
        /// Constructor de la clase FrmATM.
        /// </summary>
        /// <param name="tarjetaService">Servicio de tarjetas.</param>
        /// <param name="operacionService">Servicio de operaciones.</param>
        public FrmATM(ITarjetaService tarjetaService, IOperacionService operacionService)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario principal se carga.
        /// </summary>
        private void FrmHome_Load(object sender, EventArgs e)
        {
            // Abre el formulario hijo FrmHome al cargar el formulario principal.
            OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, this));
        }

        /// <summary>
        /// Abre un formulario hijo en el panel designado.
        /// </summary>
        /// <param name="childForm">Formulario hijo a abrir.</param>
        public void OpenChildForm(Form childForm)
        {
            // Cierra el formulario hijo actual si hay alguno abierto.
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // Configura el formulario hijo y lo muestra en el panel designado.
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
