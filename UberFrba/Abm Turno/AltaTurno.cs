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

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurno : Form
    {
        private DAOTurnos dao;
        int turnoId;

        public AltaTurno()
        {
            this.turnoId = 0;
            this.dao = new DAOTurnos();
            InitializeComponent();
        }

        public AltaTurno(DataGridViewRow row)
        {
            InitializeComponent();
            this.Text = "Modifique al turno";
            this.saveButton.Text = "Modificar";
            this.dao = new DAOTurnos();

            this.turnoId = (int)row.Cells["Id"].Value;
            this.completarCampos(row);
        }

        private void completarCampos(DataGridViewRow row)
        {
            try
            {
                this.fieldDescription.Text = row.Cells["Descripcion"].Value.ToString();
                this.timeInicio.Text = row.Cells["Hora de Inicio"].Value.ToString();
                this.timeFin.Text = row.Cells["Hora de Finalizacion"].Value.ToString();
                this.valorKm.Text = row.Cells["Valor del Kilometro"].Value.ToString();
                this.precioBase.Text = row.Cells["Precio Base"].Value.ToString();
                this.checkHabilitado.Checked = (bool)row.Cells["Habilitado"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error al cargar campos");
            }
        }

        public bool CheckEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(this.fieldDescription.Text) ||
                string.IsNullOrWhiteSpace(this.timeInicio.Text) ||
                string.IsNullOrWhiteSpace(this.timeFin.Text) ||
                string.IsNullOrWhiteSpace(this.valorKm.Text) ||
                string.IsNullOrWhiteSpace(this.precioBase.Text))
            {
                MessageBox.Show("Complete todos los campos");
                return false;
            }
            else return true;
        }

        private bool createTurno(DAOTurnos dao)
        {
            bool success = false;
            if (this.CheckEmptyFields() && dao.turnoValido((int)this.timeInicio.Value, (int)this.timeFin.Value, this.turnoId))
            {
                try
                {
                    dao.crearTurno(this.fieldDescription.Text, (int)this.timeInicio.Value, (int)this.timeFin.Value, this.valorKm.Text, this.precioBase.Text, this.checkHabilitado.Checked);
                    success = true;
                    MessageBox.Show("El turno fue creado exitosamente");
                    this.Close();
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error al crear turno");
                }
            }
            return success;
        }

        private bool updateOrDeleteTurno(DAOTurnos dao)
        {
            bool success = false;
            if (this.verifyFields() && this.CheckEmptyFields())
            {
                try
                {
                    dao.modificarturno(this.turnoId, this.fieldDescription.Text, (int)this.timeInicio.Value, (int)this.timeFin.Value, this.valorKm.Text, this.precioBase.Text, this.checkHabilitado.Checked);
                    success = true;
                    MessageBox.Show("El turno fue modificado exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error al modificar turno");
                }
            }
            return success;
        }

        private bool verifyFields()
        {
            if (!(dao.descripcionYaUsada(this.fieldDescription.Text, this.turnoId)) && !(dao.solapamiento((int)this.timeInicio.Value, (int)this.timeFin.Value, this.turnoId)) && dao.noHaceSolapar((int)this.timeInicio.Value, (int)this.timeFin.Value, this.turnoId))
                return true;
            else
                return false;
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.turnoId != 0)
            {
                updateOrDeleteTurno(dao);
            }
            else
            {
                createTurno(dao);
            }
        }
   }
}
