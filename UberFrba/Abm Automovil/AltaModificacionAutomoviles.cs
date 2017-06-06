using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;

namespace UberFrba.Abm_Automovil
{
    public partial class AltaModificacionAutomoviles : Form
    {
        private DAOAutomovil dao;
        int idAuto = 0;

        public AltaModificacionAutomoviles()
        {
            this.dao = new DAOAutomovil();
            InitializeComponent();
            setupComboMarcas();
            setupComboTurnos();
            setupComboChoferes();
        }

        public AltaModificacionAutomoviles(DataGridViewRow row)
        {
            InitializeComponent();
            /*
            this.dao = new DAOAutomovil();
            this.idAuto = id;
            this.getCar(idAuto);
            this.Text = "Modifique al cliente";
            this.buttonGuardar.Text = "Modificar";
            */
            this.completarCampos(row);
        }

        private void completarCampos(DataGridViewRow row)
        {
            this.comboMarca.SelectedItem = row.Cells["Chofer"].Value;
        }
        private void getCar(int id)
        {
        }

        private void setupComboMarcas()
        {
            this.comboMarca.ValueMember = "id";
            this.comboMarca.DisplayMember = "description";
            this.comboMarca.DataSource = dao.getAllBrands();
            this.comboMarca.SelectedItem = null;
        }

        private void setupComboTurnos()
        {
            this.comboTurno.ValueMember = "id";
            this.comboTurno.DisplayMember = "id";
            this.comboTurno.DataSource = dao.getAllTurn();
        }

        private void setupComboChoferes()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "Id";
            this.comboChofer.DataSource = dao.getAllDriver();
        }

    }
}
