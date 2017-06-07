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
        private DataGridViewRow unAuto;

        public AltaModificacionAutomoviles()
        {
            this.dao = new DAOAutomovil();
            InitializeComponent();
            setupComboMarcas();
            setupComboTurnos();
            setupComboChoferes();
        }

        public AltaModificacionAutomoviles(DataGridViewRow unAuto)
        {
            this.dao = new DAOAutomovil();
            this.unAuto = unAuto;
            InitializeComponent();
            setupComboMarcas();
            setupComboTurnos();
            setupComboMarcas();
            this.Text = "Modifique al cliente";
            this.buttonGuardar.Text = "Modificar";
            this.buttonEliminar.Enabled = true;
            this.flagAuto = 1;
            this.completarCampos(unAuto);
        }

        private void completarCampos(DataGridViewRow unAuto)
        {
            Marca marca = new Marca(unAuto);
            Turno turno = new Turno(unAuto);
            Chofer chofer = new Chofer(unAuto);
            this.comboMarca.Text = marca.getMarca();
            this.textModelo.Text = unAuto.Cells["Modelo"].Value.ToString();
            this.textPatente.Text = unAuto.Cells["Patente"].Value.ToString();
            this.comboTurno.Text = turno.getTurno();
            this.comboChofer.Text = chofer.getChofer();
            this.checkHabilitado.Checked = (bool)unAuto.Cells["Habilitado"].Value;
        }

        public void CheckEmptyFields()
        {   
            List<TextBox> inputsText = new List<TextBox> {this.textModelo, this.textPatente};
            if (inputsText.Any((t) => t.Text == ""))
            {
                throw new Exception ("Complete todos los campos"); //Implementar ExceptionCustom para poder manejar este error.
            }
            
            List<ComboBox> inputsCombo = new List<ComboBox> { this.comboChofer, this.comboMarca, this.comboTurno };
            if (inputsCombo.Any((c) => c.SelectedItem == null))
            {
                throw new Exception("Debe seleccionar chofer, combo y turno");
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
        }

        private void updateCar()
        {
            try {
                CheckEmptyFields();
                //Auto auto = getFormData();
                //dao.modificarAuto(auto);
                MessageBox.Show("Cambios guardados");
            }catch(Exception ex){
                MessageBox.Show(ex.Message.ToString());//La version final debe mostrar mensaje generico como el de abajo, Debemos manejar exceptiones propias.
                //MessageBox.Show("No se pudo actualizar su auto, comuniquese con el administrador");
            }
            
        }

        private void verifyCarExisted(Auto auto)
        {
            if (dao.patenteExist(auto) != 0)
            {
                throw new Exception("La patente ingresada ya existe con ese turno.");
            }
            if (dao.modelOrBrandDifferent(auto) != 0)
            {
                throw new Exception("La patente ingresada ya existe con otro modelo u otra marca.");
            }
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
            this.comboTurno.DisplayMember = "descripcion";
            this.comboTurno.DataSource = dao.getAllTurn();
            this.comboTurno.SelectedItem = null;
        }

        private void setupComboChoferes()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "chofer";
            this.comboChofer.DataSource = dao.getAllDriverFree();
            this.comboChofer.SelectedItem = null;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.flagAuto != 0)
            {
                updateCar();
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
            return new Auto(textPatente.Text, checkHabilitado.Checked, c.getId(), m.getId(), textModelo.Text, t.getId());
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            dao.deleteAuto(unAuto);
        }
    }
}
