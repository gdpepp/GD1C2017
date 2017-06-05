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
            DataTable dt = dao.getAllCars();
            DataView view = dt.DefaultView;
            view.RowFilter = string.Empty;

            if (textChofer.Text != string.Empty)
            {
                string filtroChofer = string.Concat("[", dt.Columns[0].ColumnName, "]");
                view.RowFilter = filtroChofer + " LIKE '%" + textChofer.Text + "%'";
            }

            if (textPatente.Text != string.Empty)
            {
                string filtroPatente = string.Concat("[", dt.Columns[1].ColumnName, "]");
                view.RowFilter = filtroPatente + " LIKE '%" + textPatente.Text + "%'";
            }

            if (comboMarca.SelectedItem != null) 
            {
                string filtroMarca = string.Concat("[", dt.Columns[2].ColumnName, "]");
                view.RowFilter = filtroMarca + " LIKE '%" + comboMarca.SelectedItem + "%'";
            }

            if (textModelo.Text != string.Empty)
            {
                string filtroModelo = string.Concat("[", dt.Columns[3].ColumnName, "]");
                view.RowFilter = filtroModelo + " LIKE '%" + textModelo.Text + "%'";
            }
            this.comboMarca.SelectedItem = null;
            this.dataGridViewAutomoviles.DataSource = view;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewAutomoviles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un auto del listado para modificar");
                return;
            }

            int idAuto = Int32.Parse(dataGridViewAutomoviles.SelectedRows[0].Cells[""].Value.ToString());
            new AltaModificacionAutomoviles(idAuto).Show();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            AltaModificacionAutomoviles a = new AltaModificacionAutomoviles();
            a.ShowDialog();
        }
    }
}