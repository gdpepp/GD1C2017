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
using UberFrba.Abm_Automovil;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {
        private List<ViajeChofer> choferes;
        private List<Turno> turnos ;
        private int idechofer;
        private DAOViajes dao;
        private DAOAutomovil tur;
        private DAORendicionViaje daoren;
        private int precalculo = 0;
    

        public RendicionViaje()
        {
            InitializeComponent();
            idechofer = 0;
            this.choferes = new List<ViajeChofer>();
            this.turnos = new List<Turno>();
            this.dao = new DAOViajes();
            this.tur = new DAOAutomovil();
            this.daoren = new DAORendicionViaje();
            choferes = dao.getAllDrivers();
            turnos = tur.getAllTurn();
            setComboCHofer();
            setComboTurno();
        }


        private void setComboCHofer()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "prettyName";
            this.comboChofer.Sorted = true;
            this.comboChofer.DataSource = choferes;
        }

        private void setComboTurno()
        {
            this.cbTurno.ValueMember = "id";
            this.cbTurno.DisplayMember = "Descripcion";
            this.cbTurno.Sorted = true;
            this.cbTurno.DataSource = turnos;
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
           precalculo = 1;
            if (datosFaltantes())               
                MessageBox.Show("No se puede realizar una busqueda, por favor complete la informacion adecuada");
            else
                generarRendicion(); 
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
            if (this.cbTurno.Text == "" || this.fechaRendicion.Value == DateTime.Today || this.comboChofer.Text == "")
                return true;
            else
                return false;
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

        private void btRendir_Click(object sender, EventArgs e)
        {
            if (datosFaltantes())
            {
                MessageBox.Show("Por favor complete los Datos");
            }
            else
            {
                if (precalculo == 1)
                {
                   daoren.setRencidion(this.idechofer, fechaRendicion, dgMontoTotal);
                   precalculo = 0;
                }
                else
                    MessageBox.Show("Por favor calcule la Rendicion");
            }
        }

        
    }
}
