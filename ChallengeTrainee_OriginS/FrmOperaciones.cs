using ATM.Application.Interfaces;
using ChallengeTrainee_OriginS;
using Core;
using Infrastructure.Persistence;

namespace Presentation
{
    public partial class FrmOperaciones : Form
    {
        private readonly ITarjetaService _tarjetaService;
        private readonly IOperacionService _operacionService;

        private Db_Connection db;

        Tarjeta _tarjetaEncontrada;

        private FrmATM _parentForm;

        public FrmOperaciones(ITarjetaService tarjetaService, IOperacionService operacionService, Db_Connection db, Tarjeta tarjetaEncontrada, FrmATM parentForm)
        {
            InitializeComponent();

            this._operacionService = operacionService;
            this._tarjetaService = tarjetaService;
            this.db = db;
            this._tarjetaEncontrada = tarjetaEncontrada;

            this._parentForm = parentForm;
        }

        private void FrmOperaciones_Load(object sender, EventArgs e)
        {
            lblCliente.Text = $"{_tarjetaEncontrada.Cliente.Nombre} {_tarjetaEncontrada.Cliente.Apellido}";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.OpenChildForm(new FrmHome(_tarjetaService, _operacionService, db, _parentForm));
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            if(_operacionService.RealizarBalance(_tarjetaEncontrada))
            {
                _parentForm.OpenChildForm(new FrmBalance(_tarjetaService, _operacionService, db, _tarjetaEncontrada, _parentForm));
                this.Close();
            }
        }
    }
}
