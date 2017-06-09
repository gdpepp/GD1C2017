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
            this.dgvAutos.DataSource = dao.getAllCars();
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
                Marca marca = this.comboMarca.SelectedItem as Marca;
                this.dgvAutos.DataSource = dao.searchCar(marca.getMarca(), textPatente.Text, textModelo.Text, textChofer.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }               
        }

        private void llenarAutos(DataTable table)
        {
            //this.dataGridViewAutomoviles.DataSource = table;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            AltaModificacionAutomoviles a = new AltaModificacionAutomoviles();
            a.ShowDialog();
        }

        private void dgvAutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow unAuto = this.dgvAutos.SelectedRows[0];
            bool flagAgregarTurno = false;
            AltaModificacionAutomoviles modificacion = new AltaModificacionAutomoviles(unAuto, flagAgregarTurno);
            modificacion.FormClosed += new System.Windows.Forms.FormClosedEventHandler(AltaModificacionAutomovilesCerrada);
            modificacion.Show();
        }

        private void AltaModificacionAutomovilesCerrada(object sender, FormClosedEventArgs e)
        {
            this.setupGrid();
        }

        private void buttonAgregarTurno_Click(object sender, EventArgs e)
        {
            if (this.dgvAutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("seleccione un auto del listado para agregar turno");
                return;
            }
            DataGridViewRow unAuto = this.dgvAutos.SelectedRows[0];
            bool flagAgregarTurno = true;
            AltaModificacionAutomoviles modificacion = new AltaModificacionAutomoviles(unAuto, flagAgregarTurno);
            modificacion.FormClosed += new System.Windows.Forms.FormClosedEventHandler(AltaModificacionAutomovilesCerrada);
            modificacion.Show();
        }
    }
}