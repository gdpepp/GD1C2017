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
using UberFrba.Utils;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {
        private Usuario user;
        private List<ViajeChofer> choferes;
        private List<Turno> turnos ;
        private int idechofer;
        private DAOViajes dao;
        private DAOAutomovil tur;
        private DAORendicionViaje daoren;
        private int precalculo = 0;
        private int idturno =0;
        private string fecha;
         
        
    

        public RendicionViaje()
        {
            InitializeComponent();
            
            
             user = UserLogin.getInstance().User;
             idechofer = user.getId();
            if (user.getRol().getId().Equals(1))
            {
                cargarTodo();
            }
            else
            {
                cargarPorUsuario();
            }
 
        }

        private void cargarPorUsuario()
        {
            this.fechaRendicion.Value = DateUtils.getDateFromConfig();
            this.choferes = new List<ViajeChofer>();
            this.turnos = new List<Turno>();
            this.dao = new DAOViajes();
            this.tur = new DAOAutomovil();
            this.daoren = new DAORendicionViaje();
            this.cbTurno.Enabled = false;
            this.comboChofer.Enabled = false;
            this.btCalcular.Enabled = false;
            this.btRendir.Enabled = false;
            this.fechaRendicion.Enabled = true;
            turnos = tur.getAllTurn();
            setComboTurno();
            List<ViajeChofer> ca = daoren.getviajessinturno(this.idechofer) ;
            if (ca.Count().Equals(0)) 
            {
                MessageBox.Show("Usted no posee viajes");
                this.fechaRendicion.Enabled = false;
            }
            else
            {
                ViajeChofer c = ca.First();
                this.idechofer = c.getId();
                this.txtCNombre.Text = c.getName();
                this.txtCApellido.Text = c.getLastname();
                this.txtCDoc.Text = c.getDoc();
                this.txtCTel.Text = c.getPhone();
                this.txtCMail.Text = c.getEmail();
                this.dtCFecha.Value = c.getDate();
                //this.btCalcular.Enabled = true;
                dgViajesRealizados.DataSource = null;
                dgMontoTotal.DataSource = null;
                //dgViajesRealizados.Refresh();
                //dgMontoTotal.Refresh();
            }
            

        }
        private void cargarviajesdelusuario(){

            
            this.fechaRendicion.Enabled = false;
            this.btCalcular.Enabled = false;
            //choferes = dao.getAllDrivers();
            //this.fechaRendicion.Value = DateTime.Today;
            choferes = daoren.getviajesbyfechasinturno(this.fecha, this.idechofer);
             if (choferes.Count > 0)
            {
                generarRendicion();
                if (daoren.existren(this.fecha, this.idechofer)) { }
                else
                {
                    this.btRendir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("en esta fecha no hay viajes para rendir");
                cargarPorUsuario();
            }
        }
 
        
        private void cargarTodo(){
            this.fechaRendicion.Value = DateTime.Today;
            this.choferes = new List<ViajeChofer>();
            this.turnos = new List<Turno>();
            this.dao = new DAOViajes();
            this.tur = new DAOAutomovil();
            this.daoren = new DAORendicionViaje();
            turnos = tur.getAllTurn();
            this.cbTurno.Enabled = false;
            this.comboChofer.Enabled = false;
            this.btCalcular.Enabled = false;
            this.btRendir.Enabled = false;
            this.fechaRendicion.Enabled = true;
            setComboTurno();
            dgViajesRealizados.DataSource = null;
            dgMontoTotal.DataSource = null;
            //dgViajesRealizados.Refresh();
            //dgMontoTotal.Refresh();
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
            this.btCalcular.Enabled = false;
            if (daoren.existren(this.fecha,this.idechofer))
            {}
            else
            { this.btRendir.Enabled = true;}
        }

        private void generarRendicion()
        {

            if (idechofer == 0)
                MessageBox.Show("No se puede realizar una busqueda, por favor complete la informacion adecuada");
            else
            {
                //string n =  fechaRendicion.Value.ToString("yyyy-MM-dd");
                dgViajesRealizados.DataSource = daoren.getviajes(idechofer,this.fecha,idturno);
                dgMontoTotal.DataSource = daoren.getTotal(idechofer, this.fecha);
              
            }
        }




        private bool datosFaltantes()
        {
            if (this.cbTurno.Text == "" || this.fechaRendicion.Value == DateTime.Today || this.comboChofer.Text == "")
                if (user.getRol().getId().Equals(1))
                {
                    return true;
                }
                    else
                {return false;
                }
            else
                return false;
        }

        private void RendicionViaje_Load(object sender, EventArgs e)
        {

        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turno t = this.cbTurno.SelectedItem as Turno;
                this.idturno = t.getId();
                this.fecha = fechaRendicion.Value.ToString("yyyy-MM-dd");
                this.fechaRendicion.Enabled = false;
            //choferes = dao.getAllDrivers();

                if (user.getRol().getId().Equals(1))
                {
                    choferes = daoren.getviajesbyfecha(this.fecha, this.idturno);
                    if (choferes.Count > 0)
                    {
                        setComboCHofer();
                        this.comboChofer.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("en esta fecha y turno no hay choferes para rendir");
                        cargarTodo();
                    }
                }
                else
                {

                    cargarviajesdelusuario();
                    // this.fecha = fechaRendicion.Value.ToString("yyyy-MM-dd");
                    //choferes = daoren.getviajessinturno(user.getId(), this.fecha);

                }





        }

        private void choferesconviaje()
        {
          // List<ViajeChofer> chof = daoren.getviajesbyfecha(this.fecha);
          // choferes.RemoveAll(chofer => !chof.Contains(chofer) );
            //todo esta mierda saque a todos los que no estan en chof
        }

        private void comboChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbTurno.Enabled = false;
            ViajeChofer c = this.comboChofer.SelectedItem as ViajeChofer;
            this.txtCNombre.Text = c.getName();
            this.txtCApellido.Text = c.getLastname();
            this.txtCDoc.Text = c.getDoc();
            this.txtCTel.Text = c.getPhone();
            this.txtCMail.Text = c.getEmail();
            this.dtCFecha.Value = c.getDate();
            this.idechofer = c.getId();
            this.btCalcular.Enabled = true;


        }

        private void btRendir_Click(object sender, EventArgs e)
        {
            if (datosFaltantes())
            {
                MessageBox.Show("Por favor complete los Datos");
            }
            else
            {
                if (precalculo == 1 && daoren.existren(this.fecha,this.idechofer))
                { try
                    {
                   daoren.setRencidion(this.idechofer, fechaRendicion, dgMontoTotal);
                   precalculo = 0;
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    precalculo = 0;
                }

                }
                else
                    MessageBox.Show("Por favor calcule la Rendicion");
            }
        }

        private void fechaRendicion_ValueChanged(object sender, EventArgs e)
        {
            this.cbTurno.Enabled = true;           
        }

        private void btNewcarga_Click(object sender, EventArgs e)
        {
            if (user.getRol().getId().Equals(1))
            {
                cargarTodo();
            }
            else 
            {
                cargarPorUsuario();
            }
        }

      private void groupdatosRendicion_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
