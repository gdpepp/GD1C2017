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
        public DataGridViewRow unAuto;
        private Turno turnoViejo;

        public AltaModificacionAutomoviles()
        {
            this.dao = new DAOAutomovil();
            InitializeComponent();
            this.comboTurno.Enabled = false;
            setupComboMarcas();
            setupComboChoferes();
        }

        public AltaModificacionAutomoviles(DataGridViewRow unAuto, bool flagAgregarTurno)
        {
            this.dao = new DAOAutomovil();
            this.unAuto = unAuto;
            InitializeComponent();
            this.turnoViejo = new Turno(unAuto);
            if (flagAgregarTurno == true)
            {
                this.groupDatosAuto.Enabled = false;
                this.comboChofer.Enabled = false;
                this.checkHabilitado.Enabled = false;
                this.flagAuto = 1;

                this.Text = "Agregar Turno";
                Chofer_Auto unChofer = new Chofer_Auto(unAuto);
                setupComboTurnos(unChofer);
            }
            else
            {
                this.Text = "Modifique al cliente";
                this.buttonGuardar.Text = "Modificar";
                this.buttonEliminar.Enabled = true;
                this.flagAuto = 2;
                setupComboMarcas();
                setupComboChoferes();
            }

            this.completarCampos(unAuto);
        }

        private void completarCampos(DataGridViewRow unAuto)
        {
            Marca marca = new Marca(unAuto);
            Turno turno = new Turno(unAuto);
            Chofer_Auto chofer = new Chofer_Auto(unAuto);
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
                MessageBox.Show(ex.Message.ToString());
                //La version final debe mostrar mensaje generico como el de abajo, Debemos manejar exceptiones propias.
                //MessageBox.Show("No se pudo registrar el auto");
            }
        }

        private void updateCar()
        {
            try {
                CheckEmptyFields();
                Auto auto = getFormData();
                auto.idAuto = (int)unAuto.Cells["IdAutos"].Value;
                auto.idModelo = (int)unAuto.Cells["IdModelo"].Value;
                if (auto.patente != (string)unAuto.Cells["Patente"].Value)
                {
                    verifyCarExisted(auto);
                }
                dao.updateAuto(auto, turnoViejo);
                MessageBox.Show("Cambios guardados");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());//La version final debe mostrar mensaje generico como el de abajo, Debemos manejar exceptiones propias.
                //MessageBox.Show("No se pudo actualizar su auto, comuniquese con el administrador");
            }
            
        }

        private void verifyCarExisted(Auto auto)
        {
            if (dao.carExists(auto) != 0)
            {
                throw new Exception("La patente ingresada ya existe.");
            }
        }

        private void setupComboMarcas()
        {
            this.comboMarca.ValueMember = "id";
            this.comboMarca.DisplayMember = "description";
            this.comboMarca.DataSource = dao.getAllBrands();
            this.comboMarca.SelectedItem = null;
        }

        private void setupComboTurnos(Chofer_Auto unChofer)
        {
            this.comboTurno.ValueMember = "id";
            this.comboTurno.DisplayMember = "descripcion";
            this.comboTurno.DataSource = dao.getAllTurnFree(unAuto, unChofer);
            this.comboTurno.SelectedItem = null;
        }

        private void setupComboChoferes()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "chofer";
            this.comboChofer.DataSource = dao.getAllDriverFree(unAuto);
            this.comboChofer.SelectedItem = null;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.flagAuto == 0)
            {
                createCar();
                return;
            }
            if (this.flagAuto == 1)
            {
                createNewTurn();
                this.Close();
            }
            else
            {
                updateCar();
            }
        }

        private void createNewTurn()
        {
            try
            {
                if (comboTurno.SelectedIndex.Equals(-1))
                {
                    throw new Exception("Debe seleccionar un turno");
                }
                Turno turno = this.comboTurno.SelectedItem as Turno;
                if (turno.getId() != (int)unAuto.Cells["IdTurno"].Value)
                {
                    dao.createTurno(unAuto, turno);
                    MessageBox.Show("El turno fue agregado con exito");
                }
                else
                {
                    MessageBox.Show("El turno no cambio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private Auto getFormData() 
        {
            Marca m = this.comboMarca.SelectedItem as Marca;
            Turno t = this.comboTurno.SelectedItem as Turno;
            Chofer_Auto c = this.comboChofer.SelectedItem as Chofer_Auto;
            return new Auto(textPatente.Text, checkHabilitado.Checked, c.getId(), m.getId(), textModelo.Text, t.getId());
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CheckEmptyFields();
                DialogResult resul = MessageBox.Show("Seguro que quiere eliminar el Auto?", "Eliminar Registro", MessageBoxButtons.YesNo);
                if (resul == DialogResult.Yes)
                {
                    dao.deleteAuto(unAuto);
                    MessageBox.Show("El auto fue eliminado exitosamente");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void comboChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboTurno.Enabled = true;
            Chofer_Auto unChofer = this.comboChofer.SelectedItem as Chofer_Auto;
            this.setupComboTurnos(unChofer);
        }

    }
}
