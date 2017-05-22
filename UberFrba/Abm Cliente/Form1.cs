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

        public ABMCliente()
        {
              InitializeComponent();
              tb_obtener_filtro.Text = inicialTB;
              CBbuscarf.Items.Insert(0, "DNI");
              CBbuscarf.Items.Insert(1, "Apellido");
              CBbuscarf.Items.Insert(2, "Nombre");
              CBbuscarf.Items.Insert(3, "Email");
              CBbuscarf.Items.Insert(4, "Teléfono");
              CBbuscarf.Items.Insert(5, "Dirección"); // query para traer de la tabla Direccion
              CBbuscarf.Items.Insert(6, "Código Postal");
              CBbuscarf.Items.Insert(7, "Fecha de Nacimiento");

              BTeliminar.Visible = false;
              BTModificar.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if ((tb_obtener_filtro.Text == inicialTB) || (CBbuscarf.Text == inicialCB)) 
            //{ MessageBox.Show("Por favor complete la informacion necesaria"); }
            //else
            //{
            //    var conection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();

            //    BTModificar.Visible = true;
            //    BTeliminar.Visible = true;
            //    bt_nuevo_cliente.Visible = false;
            //    CBbuscarf.Visible = false;
            //    tb_obtener_filtro.Visible = false;
            //    BuscarPor.Visible = false;
            //}
        }

        private void bt_Volver_Click(object sender, EventArgs e)
        {
            //BTeliminar.Visible = false;
            //BTModificar.Visible = false;
            //bt_nuevo_cliente.Visible = true;
            //CBbuscarf.Visible = true;
            //tb_obtener_filtro.Visible = true;
            //BuscarPor.Visible = true;
           // aca hay q ver si esta lleno cb
        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void tb_obtener_filtro_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void cb_opcion_busqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BTModificar_Click(object sender, EventArgs e)
        {
            //Alta_Cliente mod = new Alta_Cliente();
            //mod.ShowDialog();

            // hacer que se cargue con la informacion que se selecciono
        }

        private void BTeliminar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        // metodos generales

        private void llenarClientes()
        {

        //    if (CBbuscarf.Text == "DNI") 
        //    {
        //        condicionWhere = "";//buscar por dni 
        //    }
        //    if (CBbuscarf.Text == "Apellido") 
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Nombre") 
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Email")
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Telefono")
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Direccion")
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Codigo postal")
        //    {
        //        condicionWhere = "";//buscar por
        //    }
        //    if (CBbuscarf.Text == "Fecha de Nacimiento")
        //    {
        //        condicionWhere = "";//buscar por
        //    } 
        //    else 
        //    {
        //        MessageBox.Show("ERROR: no puede realizarse la busqueda"); 
        //    }
            
        //var connection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();
        //SqlCommand get_Clientes = new SqlCommand("FSOCIETY.sp_get_clientes", connection);
        //get_Clientes.Parameters.Add(new SqlParameter("@NombreTabla", this.condicionWhere));
        //get_Clientes.Parameters.Add(new SqlParameter("@itemABuscar", this.tb_obtener_filtro.Text));
        //get_Clientes.CommandType = CommandType.StoredProcedure;
        //connection.Open();
        //SqlDataReader reader = get_Clientes.ExecuteReader();
        }

        private void CBbuscarf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_nuevo_cliente_Click(object sender, EventArgs e)
        {

        }
    }
}
