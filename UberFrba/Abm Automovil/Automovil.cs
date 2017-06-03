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
        Form parent;
        DAOAutomovil dao;

        public Automovil(Form parent)
        {
            this.parent = parent;
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
            this.dataGridViewAutomoviles.ColumnHeadersVisible = false;
        }

        private void setupComboMarcas()
        {
            this.comboMarca.ValueMember = "id";
            this.comboMarca.DisplayMember = "description";
            this.comboMarca.DataSource = dao.getAllBrands();
        }


    }
}