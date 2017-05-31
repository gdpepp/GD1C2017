using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        private String inicialTB = "Ingrese criterio de Busqueda";
        private String inicialCB = "";
        private String condicionWhere;
        SqlDataAdapter adapter;
        Form parent;

        public ABMCliente(Form parent)

        {
            this.parent = parent;
             InitializeComponent();
             tb_obtener_filtro.Text = inicialTB;
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
            this.Hide();
            form.ShowDialog();
        }

        private void bt_Volver_Click_1(object sender, EventArgs e)
        {
            BTModificar.Visible = false;
            bt_nuevo_cliente.Visible = true;
            CBbuscarf.Visible = true;
            tb_obtener_filtro.Visible = true;
            BuscarPor.Visible = true;
            this.Close();
            parent.Show();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            if ((tb_obtener_filtro.Text == inicialTB) || (CBbuscarf.Text == inicialCB)) 
            { 
                MessageBox.Show("Por favor complete la informacion necesaria", "Error"); 
            }
            else
            {
                var conection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();

                BTModificar.Visible = true;
                bt_nuevo_cliente.Visible = false;
                CBbuscarf.Visible = false;
                tb_obtener_filtro.Visible = false;
                BuscarPor.Visible = false;

                this.llenarClientes();
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



        private void llenarClientes()
        {
            var connection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();
            SqlCommand get_Clientes = new SqlCommand("FSOCIETY.sp_get_clientes", connection);
            get_Clientes.CommandType = CommandType.StoredProcedure;
            
            get_Clientes.Parameters.Add(new SqlParameter("@fieldName", this.condicionWhere));
            get_Clientes.Parameters.Add(new SqlParameter("@fieldValue", this.tb_obtener_filtro.Text));
            
            connection.Open();
            SqlDataReader reader = get_Clientes.ExecuteReader();

            //Creo el adapter usando el select_query
            this.adapter = new SqlDataAdapter(get_Clientes);

            //Lleno el dataset y lo seteo como source del dataGridView
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

        private void BTModificar_Click_1(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("seleccione un cliente del listado para modificar");
                return;
            }

            int clientId = Int32.Parse(dataGridView1.SelectedRows[0].Cells[""].Value.ToString());
            new AltaCliente(clientId).Show();
            //TODO modificar "cod_us"
        }
                
    }
}
