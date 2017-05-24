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
                SqlConnection connection = DBConnection.getInstance().getConnection();
                SqlCommand createUser = new SqlCommand("FSOCIETY.sp_crear_usuario", connection);
                createUser.Parameters.Add(new SqlParameter("@username", this.fieldName));
                createUser.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (createUser.ExecuteNonQuery() > 0)
                {
                    SqlConnection clientConnection = DBConnection.getInstance().getConnection();
                    SqlCommand createClient = new SqlCommand("FSOCIETY.sp_crear_cliente", clientConnection);
                    createClient.Parameters.Add(new SqlParameter("@username", this.fieldName));
                    createClient.CommandType = CommandType.StoredProcedure;
                    clientConnection.Open();
                    if (createUser.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("El cliente fue creado exitosamente");
                        connection.Close();
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
                MessageBox.Show("El número de documento no puede ser 0");
                return;
            }
        }

        public bool emptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.fieldName, this.fieldSurname, this.fieldDocument, this.fieldMail, this.fieldTelephone, this.birthTimePicker, this.fieldZipcode, this.fieldStreet, this.FieldStreetNumer, this.fieldLocalidad};
            return inputs.Any((t) => t.Text == "");
        }
    }
}
