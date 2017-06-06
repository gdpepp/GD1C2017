using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UberFrba.Dao;
using WindowsFormsApplication1;
using WindowsFormsApplication1.ABM_Rol;

namespace UberFrba.Abm_Rol
{
    public partial class DefinicionRol : Form
    {
        int idRol = 0;
        private DAORoles dao;
        List<String> funcionalidadesAgregadas = new List<String>();
        List<String> funcionalidadesBorradas = new List<String>();
        List<String> funcionalidadesTodas = new List<String>();


        public DefinicionRol(DataGridViewRow row)
        {
            dao = new DAORoles();
            this.idRol = (Int32)row.Cells["Id"].Value;
            InitializeComponent();
            this.textBox1.Text = row.Cells["Descripcion"].Value.ToString();
            this.checkBox1.Checked = (bool)row.Cells["Habilitado"].Value;
            this.button1.Text = "Modificar";
            this.LlenarListaFuncionalidades();
        }

        public DefinicionRol()
        {
            InitializeComponent();
            //this.label1.Text = "Cree un nuevo rol";
            dao = new DAORoles();
            this.button1.Text = "Crear";
            this.button1.Click += this.insert;
            this.LlenarListaFuncionalidades();
        }

        private void update(object sender, EventArgs e)
        {
            /*var connection = DBConnection.getInstance().getConnection();
            SqlCommand update_command = new SqlCommand("FSOCIETY.sp_update_roles", connection);
            update_command.CommandType = CommandType.StoredProcedure;
            update_command.Parameters.Add(new SqlParameter("@idRol", this.idRol));
            update_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
            update_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            if (update_command.ExecuteNonQuery() >= 1)
            {
                this.aplicarSpAlistasFuncionalidades(this.funcionalidadesAgregadas, "FSOCIETY.sp_insert_funcionalidad");
                this.aplicarSpAlistasFuncionalidades(this.funcionalidadesBorradas, "FSOCIETY.sp_delete_funcionalidad");
                this.Close();
                MessageBox.Show("Se modificaron los campos correctamente");
                this.parent.fill_data_set();  // Para que refresque el data set
            }
            else
                MessageBox.Show("No se pudo modificar el rol. Intente nuevamente");
            connection.Close();*/
        }

        private void insert(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                /*var connection = DBConnection.getInstance().getConnection();
                SqlCommand insert_command = new SqlCommand("FSOCIETY.sp_insert_rol", connection);
                insert_command.CommandType = CommandType.StoredProcedure;
                insert_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                insert_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

                connection.Open();
                string mensaje;
                try
                {
                    int inserted_pk = Int32.Parse(insert_command.ExecuteScalar().ToString());
                    this.idRol = inserted_pk;
                    this.aplicarSpAlistasFuncionalidades(this.funcionalidadesAgregadas, "FSOCIETY.sp_insert_funcionalidad");
                    this.Close();
                    mensaje = "Rol agregado correctamente";
                    this.parent.fill_data_set();
                }
                catch
                {
                    mensaje = "No se pudo crear el rol. Intente nuevamente";
                }
                connection.Close();
                MessageBox.Show(mensaje);*/
            }
            else MessageBox.Show("Debe proveer un nombre para el rol ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LlenarListaFuncionalidades()
        {
            // Si es un update, pido las funcionalidades asignadas al rol
            if (this.idRol > 0)
            {
                this.llenarListadoFuncionalidades(dao.getAllFuncionalitiesByRol(idRol));
            }
            else
                this.llenarListadoFuncionalidades(dao.getAllFuncionalities());
                

                 }

        private void llenarListadoFuncionalidades(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++ )
            {
                object value = table.Rows[i]["relacion"];
                if (value == DBNull.Value)
                {
                    this.checkedListBox1.Items.Add(table.Rows[i]["Funcionalidades"].ToString(), false);
                }
                else
                {
                    this.checkedListBox1.Items.Add(table.Rows[i]["Funcionalidades"].ToString(), true);
                }
            }
        }

        private void aplicarSpAlistasFuncionalidades(List<Funcionalidad> list, string sp)
        {
            /*var connection = DBConnection.getInstance().getConnection();
            SqlCommand command;
            foreach (Funcionalidad funcionalidad in list)
            {
                command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@idrol", this.idRol));
                command.Parameters.Add(new SqlParameter("@idFun", funcionalidad.codigo));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }*/

        }

        //private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e)
        //{
        //    Funcionalidad changed_functionality = (Funcionalidad)this.checkedListBox1.Items[e.Index];

        //    if (e.NewValue == CheckState.Checked)
        //    {
        //        // Si antes la había marcado para quitarla, la seteo para agregar
        //        if (this.funcionalidadesBorradas.Contains(changed_functionality))
        //            this.funcionalidadesBorradas.Remove(changed_functionality);
        //        // Para no agregarla varias veces, checkeando el botón más de una vez
        //        if (!this.funcionalidadesBorradas.Contains(changed_functionality))
        //            this.funcionalidadesBorradas.Add(changed_functionality);
        //    }
        //    else
        //    {
        //        // Idem anterior, pero para quitar la funcionalidad
        //        if (this.funcionalidadesBorradas.Contains(changed_functionality))
        //            this.funcionalidadesBorradas.Remove(changed_functionality);
        //        if (!this.funcionalidadesBorradas.Contains(changed_functionality))
        //            this.funcionalidadesBorradas.Add(changed_functionality);
        //    }
        //}

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.idRol > 0)
            {

                for (int i = 0; i < this.checkedListBox1.SelectedItems.Count; i++)
                {
                    if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        this.funcionalidadesAgregadas.Add(checkedListBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        this.funcionalidadesBorradas.Add(checkedListBox1.SelectedItem.ToString());
                    }
                }
                try
                {
                    dao.update(funcionalidadesAgregadas, funcionalidadesBorradas, this.idRol, this.textBox1.Text, this.checkBox1.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    dao.insert(funcionalidadesAgregadas, this.textBox1.Text, this.checkBox1.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
