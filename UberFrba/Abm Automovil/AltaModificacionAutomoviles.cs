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
        int flagAuto = 0;
        int idAuto;

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
            this.dao = new DAOAutomovil();
            InitializeComponent();
            setupComboMarcas();
            setupComboTurnos();
            setupComboChoferes();
            this.Text = "Modifique al Auto";
            this.buttonGuardar.Text = "Modificar";
            this.flagAuto = 1;
            this.completarCampos(row);

            Auto auto = new Auto(Convert.ToInt32(this.comboMarca.SelectedValue), this.textModelo.Text, this.textPatente.Text, Convert.ToInt32(this.comboTurno.SelectedValue), Convert.ToInt32(this.comboChofer.SelectedValue), this.checkHabilitado.Checked);
            this.idAuto = dao.getIdAuto(auto);
        }

        private void completarCampos(DataGridViewRow row)
        {
            /*
            this.comboMarca.SelectedIndex = ;
            this.textModelo.Text = row.Cells["Modelo"].Value.ToString();
            this.textPatente.Text = row.Cells["Patente"].Value.ToString();
            this.comboTurno.SelectedItem = row.Cells["Turno"].Value.ToString();
            this.comboChofer.SelectedItem = row.Cells["Chofer"].Value.ToString();
            this.checkHabilitado.Checked = (bool)row.Cells["Habilitado"].Value;
            */
        }

        public bool CheckEmptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.textModelo, this.textPatente};
            if (inputs.Any((t) => t.Text == ""))
            {
                MessageBox.Show("Complete todos los campos");
                return false;
            }
            else return true;
        }

        private bool createCar(DAOAutomovil dao)
        {
            bool success = false;
            if (this.CheckEmptyFields())
            {
                Auto auto = new Auto(Convert.ToInt32(this.comboMarca.SelectedValue), this.textModelo.Text, this.textPatente.Text, Convert.ToInt32(this.comboTurno.SelectedValue), Convert.ToInt32(this.comboChofer.SelectedValue), this.checkHabilitado.Checked);
                verifyFields(dao, auto);
                try
                {
                    dao.crearAuto(auto);
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                MessageBox.Show("El auto fue creado exitosamente");
                this.Close();
            }
            return success;
        }

        private void updateOrDeleteCar(DAOAutomovil dao)
        {
            Auto auto = new Auto(Convert.ToInt32(this.comboMarca.SelectedValue), this.textModelo.Text, this.textPatente.Text, Convert.ToInt32(this.comboTurno.SelectedValue), Convert.ToInt32(this.comboChofer.SelectedValue), this.checkHabilitado.Checked);
            dao.modificarAuto(auto);
            verifyFields(dao, auto);
            MessageBox.Show("Cambios guardados");
        }

        private bool verifyFields(DAOAutomovil dao, Auto auto)
        {
            if (dao.getIdAuto(auto) != 0)
            {
                MessageBox.Show("La patente ingresada ya existe.", "La patente ya existe");
                return false;
            }
            return true;
        }

        private void setupComboMarcas()
        {
            this.comboMarca.ValueMember = "id";
            this.comboMarca.DisplayMember = "description";
            this.comboMarca.DataSource = dao.getAllBrands();
        }

        private void setupComboTurnos()
        {
            this.comboTurno.ValueMember = "id";
            this.comboTurno.DisplayMember = "descripcion";
            this.comboTurno.DataSource = dao.getAllTurn();
        }

        private void setupComboChoferes()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "chofer";
            this.comboChofer.DataSource = dao.getAllDriver();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.flagAuto != 0)
            {
                updateOrDeleteCar(dao);
            }
            else
            {
                createCar(dao);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
