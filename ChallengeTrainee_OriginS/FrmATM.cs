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

        public FrmATM(ITarjetaService tarjetaService, IOperacionService operacionService)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;

        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, this));
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
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
