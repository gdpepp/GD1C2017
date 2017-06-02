using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Dao;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        private String inicialTB = "Ingrese criterio de Busqueda";
        private String inicialCB = "";
        private String condicionWhere;
        private DAOClientes dao;


        public ABMCliente()
        {
            this.dao = new DAOClientes();
            InitializeComponent();
            setupTableView();
            CBbuscarf.Items.Insert(0, "DNI");
            CBbuscarf.Items.Insert(1, "Apellido");
            CBbuscarf.Items.Insert(2, "Nombre");
            CBbuscarf.Items.Insert(3, "Email");
            CBbuscarf.Items.Insert(4, "Telefono");
            CBbuscarf.Items.Insert(5, "Direccion");
            CBbuscarf.Items.Insert(6, "Codigo_Postal");
            CBbuscarf.Items.Insert(7, "Fecha_de_Nacimiento");
            BTModificar.Visible = false;

        }

        private void bt_nuevo_cliente_Click(object sender, EventArgs e)
        {
            AltaCliente form = new AltaCliente();
            form.ShowDialog();
        }


        private void bt_buscar_Click(object sender, EventArgs e)
        {
            
            try
            {   
                validateSearchOK();
                BTModificar.Visible = true;
                DataTable clientes = dao.buscarCliente(CBbuscarf.Text,tb_obtener_filtro.Text);
                this.llenarClientes(clientes);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
               
        }


        private void BTModificar_Click(object sender, EventArgs e)
        {
            //Alta_Cliente mod = new Alta_Cliente();
            //mod.ShowDialog();

            // hacer que se cargue con la informacion que se selecciono
        }

        private void BTeliminar_Click_1(object sender, EventArgs e)
        {
            //baja logica
            //llamar a un SP que inhabilite al usuario
        }



        private void llenarClientes(DataTable table)
        {
            this.dataGridView1.DataSource = table;
        }

        private void BTModificar_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("seleccione un cliente del listado para modificar");
                return;
            }

            int clientId = Int32.Parse(dataGridView1.SelectedRows[0].Cells[""].Value.ToString());
            new AltaCliente(clientId).Show();
        }

        private Boolean validateFields(String textfieldText, String initial){
            return textfieldText == initial && textfieldText == string.Empty;
        }

        private void validateSearchOK() {
            if ((tb_obtener_filtro.Text == string.Empty && CBbuscarf.Text != string.Empty) || (tb_obtener_filtro.Text != string.Empty && CBbuscarf.Text == string.Empty))
            { 
                throw new Exception("Complete ambos campos para filtrar");
            }
        }

        private void setupTableView() {
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersVisible = false;
        }

    }
}
