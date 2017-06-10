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
    public partial class AbmTurno : Form
    {
        private DAOTurnos dao;
        
        public AbmTurno()
        {
            this.dao = new DAOTurnos();
            InitializeComponent();
            this.setupTableView();
            this.bt_modificar.Visible = false;
        }

        private void bt_nuevo_Click_1(object sender, EventArgs e)
        {
            AltaTurno form = new AltaTurno();
            form.ShowDialog();
        }

        private void bt_buscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable turnos = dao.buscarTurnos(this.fieldDescription.Text);
                this.llenarTurnos(turnos);
                bt_modificar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error en carga de turnos");
            }

        }

        private void llenarTurnos(DataTable turnos)
        {
            this.dataGridView1.DataSource = turnos;
            this.dataGridView1.Columns[0].Visible = false;
            // Columna Id
        }

        private void setupTableView()
        {
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersVisible = true;
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_modificar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("seleccione un turno del listado para modificar", "Modificacion de turno");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            new AltaTurno(row).Show();
        }
    }
}
