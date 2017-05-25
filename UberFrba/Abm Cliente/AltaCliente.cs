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

                int idPersona = 0;
                String direccion = string.Concat("Calle: " + this.fieldStreet +
                                                 " numero: " + this.FieldStreetNumer +
                                                 " piso: " + this.fieldFloor +
                                                 " dto: " + this.fieldDepartment +
                                                 " localidad: " + this.fieldLocalidad);

                SqlConnection personConnection = DBConnection.getInstance().getConnection();
                SqlCommand createPerson = new SqlCommand("FSOCIETY.sp_crear_persona", personConnection);
                createPerson.Parameters.Add(new SqlParameter("@nombre", this.fieldName));
                createPerson.Parameters.Add(new SqlParameter("@apellido", this.fieldSurname));
                createPerson.Parameters.Add(new SqlParameter("@dni", this.fieldDocument));
                createPerson.Parameters.Add(new SqlParameter("@direccion", direccion));
                createPerson.Parameters.Add(new SqlParameter("@fecha_nacimiento", this.birthTimePicker.Value));
                createPerson.Parameters.Add(new SqlParameter("@id", idPersona));
                createPerson.CommandType = CommandType.StoredProcedure;
                personConnection.Open();

                if (createPerson.ExecuteNonQuery() > 0)
                {

                    SqlConnection userConnection = DBConnection.getInstance().getConnection();
                    SqlCommand createUser = new SqlCommand("FSOCIETY.sp_create_user", userConnection);
                    createUser.Parameters.Add(new SqlParameter("@idPersona", idPersona));
                    createUser.CommandType = CommandType.StoredProcedure;
                    userConnection.Open();

                    if (createUser.ExecuteNonQuery() > 0)
                    {
                        //usuario.id es fk de cliente
                        //ver si queda asi o si se cambia
                        int idCliente = 0;
                        SqlConnection clientConnection = DBConnection.getInstance().getConnection();
                        SqlCommand createClient = new SqlCommand("FSOCIETY.sp_crear_cliente", userConnection);
                        createClient.Parameters.Add(new SqlParameter("@telefono", this.fieldTelephone));
                        createClient.Parameters.Add(new SqlParameter("@mail", this.fieldMail));
                        createClient.Parameters.Add(new SqlParameter("@codigoPostal", this.fieldZipcode));
                        createClient.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                        createClient.CommandType = CommandType.StoredProcedure;
                        clientConnection.Open();

                        if (createClient.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("El cliente fue creado exitosamente");
                            personConnection.Close();
                            userConnection.Close();
                            clientConnection.Close();
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
            List<TextBox> inputs = new List<TextBox> {this.fieldName, this.fieldSurname, this.fieldDocument, this.fieldMail, this.fieldTelephone, this.fieldZipcode, this.fieldStreet, this.FieldStreetNumer, this.fieldLocalidad};
            return inputs.Any((t) => t.Text == "");
        }
    }
}
