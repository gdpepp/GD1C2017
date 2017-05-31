using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using UberFrba.Dao;

namespace UberFrba.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        int clientId = 0;

        public AltaCliente()
        {
            InitializeComponent();
        }

        public AltaCliente(int id)
        {
            InitializeComponent();
            this.clientId = id;
            this.getClient(clientId);
            this.Text = "Modifique al cliente";
            this.saveButton.Text = "Modificar";
     
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            // al guardar se hara tanto el alta como la modificacion, de acuerdo al clientId

            DAOClientes dao = new DAOClientes();
               
            if (this.clientId != 0)
            {
                updateOrDeleteClient(dao);
            }
            else 
            {
                createClient(dao);                
            }              
        }

        private void checkDNInot0()
        {
            if(!this.fieldDocument.Equals("0"))
                MessageBox.Show("El número de documento no puede ser 0");
        }

        private void getClient(int id)
        {
            SqlConnection connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("FSOCIETY.sp_get_cliente_by_id", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            this.completarCampos(command.ExecuteReader());
            connection.Close();
         }

        private void completarCampos(SqlDataReader reader)
        {
            reader.Read();
            this.fieldName.Text = reader["Nombre"].ToString();
            this.fieldSurname.Text = reader["Apellido"].ToString();
            this.fieldDocument.Text = reader["DNI"].ToString();
            this.fieldTelephone.Text= reader["Telefono"].ToString();
            this.fieldMail.Text = reader["Email"].ToString();
            this.birthTimePicker.Text = reader["[Fecha de Nacimiento]"].ToString();
            this.fieldStreet.Text = reader["Direccion"].ToString();
            this.fieldZipcode.Text = reader["Codigo_Postal"].ToString();
            this.checkHabilitado.Checked = (bool)reader["Habilitado"];
       }

        public void CheckEmptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.fieldName, this.fieldSurname, this.fieldDocument, this.fieldMail, 
                this.fieldTelephone, this.fieldZipcode, this.fieldStreet};
            if (inputs.Any((t) => t.Text == ""))
            {
                MessageBox.Show("Complete todos los campos");              
            }
        }

        private bool createClient(DAOClientes dao)
        {
            int idPersona = 0;
            Persona persona = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, idPersona);
            Cliente cliente = new Cliente(this.fieldTelephone.Text, this.fieldMail.Text, this.fieldZipcode.Text, idPersona, this.checkHabilitado.Checked);
        
            this.CheckEmptyFields();
            this.checkDNInot0();
            bool success = false;
            //primero creo la persona
            //dsp el usuario
            //dsp el cliente
            //y dsp le agrego el rol
                        
            if (dao.crearPersona(persona) > 0)
            {
                persona.setIdPersona(dao.getIdPersona(persona));

                if (dao.crearUsuario(persona.idPerson) > 0)
                {
                    //usuario.id es fk de cliente
                    //ver si queda asi o si se cambia

                    if (dao.crearCliente(cliente) > 0)
                    {
                        success = true;
                        MessageBox.Show("El cliente fue creado exitosamente");
                        cliente.setIdCliente(dao.getIdcliente(cliente));
                        dao.closeConnections();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos del cliente.\nIntente nuevamente", "Error Cliente");
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos del usuario.\nIntente nuevamente", "Error Usuario");
                }
            }
            else
            {
                MessageBox.Show("Error al guardar los datos de la persona.\nIntente nuevamente", "Error Persona");
            }
    
            return success;
        }

        private void updateOrDeleteClient(DAOClientes dao)
        {
            Persona persona = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, this.clientId);
            Cliente cliente = new Cliente(this.fieldTelephone.Text, this.fieldMail.Text, this.fieldZipcode.Text, this.clientId, this.checkHabilitado.Checked);

            verifyFields(dao, persona, cliente);
            dao.modificarPersona(persona);
            dao.modificarCliente(cliente);
        }

        private void verifyFields(DAOClientes dao, Persona persona, Cliente cliente)
        {
            if (dao.getDNIById(persona) != 0)
            {
                MessageBox.Show("El numero de DNI ya existe para otra persona", "DNI ya existe");
            }
            if (dao.getMailById(cliente) != 0)
            {
                MessageBox.Show("La direccion de mail ya existe para otra persona", "Mail ya existe");
            }
        }
    }
}