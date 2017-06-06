using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Utils;
using UberFrba.Dao;
using UberFrba.Mapping;


namespace UberFrba.Abm_Automovil
{
    public partial class Automovil : Form
    {
        private DAOAutomovil dao;

        public Automovil()
        {
            this.dao = new DAOAutomovil();
            InitializeComponent();
            setupComboMarcas();
            setupGrid();
        }

        private void setupGrid() 
        {
            this.dataGridViewAutomoviles.DataSource = dao.getAllCars();
            this.dataGridViewAutomoviles.ReadOnly = true;
            this.dataGridViewAutomoviles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAutomoviles.MultiSelect = false;
            this.dataGridViewAutomoviles.AllowUserToAddRows = false;
            this.dataGridViewAutomoviles.AllowUserToDeleteRows = false;
            this.dataGridViewAutomoviles.ColumnHeadersVisible = true;
        }

        private void setupComboMarcas()
        {
            this.comboMarca.ValueMember = "id";
            this.comboMarca.DisplayMember = "description";
            this.comboMarca.DataSource = dao.getAllBrands();
            this.comboMarca.SelectedItem = null;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {   
                DataTable autos = dao.searchCar(comboMarca.SelectedText, textPatente.Text, textModelo.Text, textChofer.Text);
                this.llenarAutos(autos);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
               
        }

        private void llenarAutos(DataTable table)
        {
            this.dataGridViewAutomoviles.DataSource = table;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewAutomoviles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un auto del listado para modificar");
                return;
            }
            DataGridViewRow row = this.dataGridViewAutomoviles.SelectedRows[0];
            new AltaModificacionAutomoviles(row).Show();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            AltaModificacionAutomoviles a = new AltaModificacionAutomoviles();
            a.ShowDialog();
        }
    }
}