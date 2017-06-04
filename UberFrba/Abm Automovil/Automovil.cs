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
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = dao.getAllCars();
            string fieldName = string.Concat("[", dt.Columns[0].ColumnName,"]");
            dt.DefaultView.Sort = fieldName;
            DataView view = dt.DefaultView;
            view.RowFilter = string.Empty;
            if (textPatente.Text != string.Empty)
                view.RowFilter = fieldName + " LIKE '%" + textPatente.Text + "%'";
            this.dataGridViewAutomoviles.DataSource = view;
        }
    }
}