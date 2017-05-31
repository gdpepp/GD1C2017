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


namespace UberFrba.Abm_Automovil
{
    public partial class Automovil : Form
    {

        SqlDataAdapter adapter;
        Form parent;

        public Automovil(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void llenarAutomovil()
        {
            var connection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();
            SqlCommand get_automoviles = new SqlCommand("[FSOCIETY].[sp_get_automoviles]", connection);
            get_automoviles.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = get_automoviles.ExecuteReader();

            this.adapter = new SqlDataAdapter(get_automoviles);

            DataTable table = new DataTable();
            this.adapter.Fill(table);
            this.dataGridView1.DataSource = table;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Columns[0].Visible = false;

            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.llenarAutomovil();
        }
    }
}