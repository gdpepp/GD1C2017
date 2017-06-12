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
using UberFrba.Mapping;
using UberFrba.Utils;

namespace UberFrba.Facturacion
{
    public partial class Facturacion : Form
    {   
        private DAOFacturacion dao;

        public Facturacion()
        {
            InitializeComponent();
            this.dao = new DAOFacturacion();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            setupComboBox();
            setupTable();
            if (cbCliente.Items.Count == 0) {
                this.btnFactura.Enabled = false;
            }
        }

        private void setupComboBox() {
            List<ClienteFactura> list = this.dao.getClientToSelect();
            this.cbCliente.ValueMember = "id";
            this.cbCliente.DisplayMember = "prettyName";
            this.cbCliente.Sorted = true;
            this.cbCliente.DataSource = list;
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            ClienteFactura cliente = this.cbCliente.SelectedItem as ClienteFactura;
            Factura f = null;
            
                f = dao.getInvoice(cliente.Id);
            
           
            if (f == null)
            {
                try
                {
                    dao.generateInvoice(cliente.Id);
                    f = dao.getInvoice(cliente.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                refreshView(cliente.Id, f);
            }
            else {
                refreshView(cliente.Id, f);
            }
            
        }

        private void loadTable(Int32 id) {
            this.dgFactura.DataSource = dao.getItemInvoice(id); 
        }

        private void refreshView(Int32 id,Factura f) {
            loadTable(id);
            lbTotal.Visible = true;
            lbTotal.Text = "Total : " + f.Total.ToString(); 
        }

        private void setupTable() {
            this.dgFactura.ReadOnly = true;
            this.dgFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgFactura.MultiSelect = false;
            this.dgFactura.AllowUserToAddRows = false;
            this.dgFactura.AllowUserToDeleteRows = false;
            this.dgFactura.ColumnHeadersVisible = true;
        
        }


        


    }
}
