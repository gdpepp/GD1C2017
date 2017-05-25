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
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.emptyFields())
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            if (!this.fieldDocument.Equals("0"))
            {
                //primero creo la persona
                //dsp el usuario
                //dsp el cliente
                //y dsp le agrego el rol

                DAOClientes dao = new DAOClientes();
                int idPersona = 0;
                String direccion = string.Concat("Calle: " + this.fieldStreet +
                                                 " numero: " + this.FieldStreetNumer +
                                                 " piso: " + this.fieldFloor +
                                                 " dto: " + this.fieldDepartment +
                                                 " localidad: " + this.fieldLocalidad);

                Persona persona = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, direccion, this.birthTimePicker.Value, idPersona);

                if (dao.crearPersona(persona) > 0)
                {
                    persona.setIdPersona(dao.getIdPersona(persona));
                 
                    if (dao.crearUsuario(persona.idPerson) > 0)
                    {
                        //usuario.id es fk de cliente
                        //ver si queda asi o si se cambia
                        int idCliente = 0;

                        Cliente cliente = new Cliente(this.fieldTelephone.Text, this.fieldMail.Text, this.fieldZipcode.Text, idPersona);

                        if (dao.crearCliente(cliente) > 0)
                        {
                            MessageBox.Show("El cliente fue creado exitosamente");
                            cliente.setIdCliente(dao.getIdcliente(cliente));
                            dao.closeConnections();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos del cliente.\nIntente nuevamente", "Error Cliente");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos del usuario.\nIntente nuevamente", "Error Usuario");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos de la persona.\nIntente nuevamente", "Error Persona");
                    return;
                }
            }
            else
            {
                MessageBox.Show("El número de documento no puede ser 0");
                return;
            }
        }

        public bool emptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.fieldName, this.fieldSurname, this.fieldDocument, this.fieldMail, 
                this.fieldTelephone, this.fieldZipcode, this.fieldStreet, this.FieldStreetNumer, this.fieldLocalidad};
            return inputs.Any((t) => t.Text == "");
        }
    }
}