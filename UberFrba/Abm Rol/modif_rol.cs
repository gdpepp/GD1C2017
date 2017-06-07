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
        List<String> funcionalidadesAgregadas;
        List<String> funcionalidadesBorradas;
        List<String> funcionalidadesTodas;


        public DefinicionRol(DataGridViewRow row)
        {
            this.funcionalidadesAgregadas = new List<String>();
            this.funcionalidadesBorradas = new List<String>();
            this.funcionalidadesTodas = new List<String>();

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
            this.funcionalidadesAgregadas = new List<String>();
            this.funcionalidadesBorradas = new List<String>();
            this.funcionalidadesTodas = new List<String>();
            
            InitializeComponent();
            //this.label1.Text = "Cree un nuevo rol";
            dao = new DAORoles();
            this.button1.Text = "Crear";
            //this.button1.Click += this.insert;
            this.LlenarListaFuncionalidades();
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

       private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            {
                if (this.idRol > 0)
                {
                    if (this.nombreNoExiste())
                    {
                        this.agregarFuncionalidadesTildadas();
                        this.agregarFuncionalidadesDestildadas();

                        try
                        {
                            dao.update(this.funcionalidadesAgregadas, this.funcionalidadesBorradas, this.idRol, this.textBox1.Text, this.checkBox1.Checked);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    else MessageBox.Show("El nombre de rol ya existe. Elija otro", "Error");
                }
                else
                {
                    if (this.nombreValido())
                    {
                        this.agregarFuncionalidadesTildadas();

                        try
                        {
                            dao.insert(ref funcionalidadesAgregadas, this.textBox1.Text, this.checkBox1.Checked);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            MessageBox.Show("Rol creado correctamente");
                            this.Close();
                        }
                    }
                }
            }
        }

        private bool nombreNoExiste()
        {
            return dao.getAnotherRolIdById(this.idRol, this.textBox1.Text).Equals(0);
        }

        private bool nombreValido()
        {
            if (this.textBox1.Text.Equals(null))
            {
                MessageBox.Show("Debe proveer un nombre para el rol ", "Error");
                return false;
            }
            else 
            {
                if((dao.buscarRol(this.textBox1.Text)).Rows.Count >0)
                {
                    MessageBox.Show("El nombre de rol ya existe. Elija otro", "Error");
                    return false;
                }
            }
    
            return true;
        }

        private void agregarFuncionalidadesDestildadas()
        {
            //int count =  this.checkedListBox1.Items.Count
            foreach (object item in checkedListBox1.Items)
            {
                if (!checkedListBox1.CheckedItems.Contains(item))
                {
                    this.funcionalidadesBorradas.Add(item.ToString());
                }
            }
        }

        private void agregarFuncionalidadesTildadas()
        {
            int sCount = checkedListBox1.CheckedItems.Count;

            for (int i = 0; i < sCount; i++)
            {
                String item = checkedListBox1.CheckedItems[i].ToString();
                this.funcionalidadesAgregadas.Add(item);
            }
        }
    }
}
