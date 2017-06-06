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
using UberFrba.Mapping;

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

        public void CheckEmptyFields()
        {   
            List<TextBox> inputs = new List<TextBox> {this.textModelo, this.textPatente};
            if (inputs.Any((t) => t.Text == ""))
            {
                throw new Exception ("Complete todos los campos"); //Implementar ExceptionCustom para poder manejar este error.
            }
        }

        private void createCar()
        {
          
                try
                {
                    CheckEmptyFields();
                    Auto auto = getFormData();
                    verifyCarExisted(auto);
                    dao.crearAuto(auto);
                    MessageBox.Show("El auto fue creado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());//La version final debe mostrar mensaje generico como el de abajo, Debemos manejar exceptiones propias.
                    //MessageBox.Show("No se pudo registrar el auto");
                }

                
                this.Close();//Chequear si quiero cerrarlo siempre.


        }

        private void updateOrDeleteCar()
        {
            try {
                CheckEmptyFields();
                Auto auto = getFormData();
                dao.modificarAuto(auto);
                MessageBox.Show("Cambios guardados");
            }catch(Exception ex){
                MessageBox.Show(ex.Message.ToString());//La version final debe mostrar mensaje generico como el de abajo, Debemos manejar exceptiones propias.
                //MessageBox.Show("No se pudo actualizar su auto, comuniquese con el administrador");
            }
            
        }

        private void verifyCarExisted(Auto auto)
        {
            if (dao.getIdAuto(auto) != 0)
            {
                throw new Exception("La patente ingresada ya existe.");
            }
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
                updateOrDeleteCar();
            }
            else
            {
                createCar();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Auto getFormData() {
            Marca m = this.comboMarca.SelectedItem as Marca;
            Turno t = this.comboTurno.SelectedItem as Turno;
            Chofer c = this.comboChofer.SelectedItem as Chofer;
            return new Auto(m.getId(), this.textModelo.Text, this.textPatente.Text, t.getId(), c.getId(), this.checkHabilitado.Checked);
        }

    }
}
