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
using UberFrba.Abm_Cliente;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {
        private List<ViajeChofer> choferes;
        private int idechofer;
        private DAOViajes dao;
        private DAORendicionViaje daoren;
    

        public RendicionViaje()
        {
            InitializeComponent();
            idechofer = 0;
            this.choferes = new List<ViajeChofer>();
            this.dao = new DAOViajes();
            this.daoren = new DAORendicionViaje();
            choferes = dao.getAllDrivers();
            setComboCHofer();
        }


        private void setComboCHofer()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "prettyName";
            this.comboChofer.Sorted = true;
            this.comboChofer.DataSource = choferes;
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            if (datosFaltantes())
                generarRendicion();     
            else
                MessageBox.Show("No se puede realizar una busqueda, por favor complete la informacion adecuada");    
           
        }

        private void generarRendicion()
        {

            if (idechofer == 0)
                MessageBox.Show("No se puede realizar una busqueda, por favor complete la informacion adecuada");
            else
            {
                string n =  fechaRendicion.Value.ToString("yyyy-MM-dd");
                dgViajesRealizados.DataSource = daoren.getviajes(idechofer,n );
                dgMontoTotal.DataSource = daoren.getTotal(idechofer, n);
              
            }
        }




        private bool datosFaltantes()
        {
            return (true);
        }

        private void RendicionViaje_Load(object sender, EventArgs e)
        {

        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViajeChofer c = this.comboChofer.SelectedItem as ViajeChofer;
            this.txtCNombre.Text = c.getName();
            this.txtCApellido.Text = c.getLastname();
            this.txtCDoc.Text = c.getDoc();
            this.txtCTel.Text = c.getPhone();
            this.txtCMail.Text = c.getEmail();
            this.dtCFecha.Value = c.getDate();
            this.idechofer = c.getId();

        }
    }
}
