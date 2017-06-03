using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;
using System.Data.SqlClient;
using WindowsFormsApplication1;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Abm_Cliente;


namespace UberFrba.Dao
{
    class DAOClientes
    {
        private DataBaseConnector connector;


        public DAOClientes() {
            this.connector = DataBaseConnector.getInstance();
        }
       

        public DataTable buscarCliente(String nombre, String apellido, String dni) {
            if (nombre != "" || apellido != "" || dni != "")
            {
                return connector.select_query(getSelectClientQuery(nombre,apellido,dni));
            }
            else {
                return buscarTodosLosClientes();
            }
                        
        }

        public DataTable buscarTodosLosClientes() {
            return connector.select_query(getAllClientQuery());
        }

        public int crearPersona(Persona persona) 
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@nombre",persona.nombre);
            dic.Add("@apellido", persona.apellido);
            dic.Add("@dni", persona.dni);
            dic.Add("@direccion", persona.direccion);
            dic.Add("@fecha_nacimiento", persona.nacimiento);
            dic.Add("@id", persona.idPerson);

            connector.executeProcedureWithParameters("FSOCIETY.sp_crear_persona", dic);
            
            
            
            /*SqlCommand createPerson = new SqlCommand("FSOCIETY.sp_crear_persona", personConnection);
            createPerson.Parameters.Add(new SqlParameter("@nombre", persona.nombre));
            createPerson.Parameters.Add(new SqlParameter("@apellido", persona.apellido));
            createPerson.Parameters.Add(new SqlParameter("@dni", persona.dni));
            createPerson.Parameters.Add(new SqlParameter("@direccion", persona.direccion));
            createPerson.Parameters.Add(new SqlParameter("@fecha_nacimiento", persona.nacimiento));
            createPerson.Parameters.Add(new SqlParameter("@id", persona.idPerson));
            createPerson.CommandType = CommandType.StoredProcedure;
            personConnection.Open();
            
            return createPerson.ExecuteNonQuery();
             * */
            return persona.idPerson;
        }

        public int getIdPersona(Persona persona)
        {
            DataBaseConnector db;
            db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("Select Id from FSOCIETY.Usuarios where Username = '" + persona.idPerson + "'");
            
            return dt.Rows[1].Field<int>(1);
        }

        public int crearUsuario(int id)
        {
            /*SqlCommand createUser = new SqlCommand("FSOCIETY.sp_create_user", userConnection);
            createUser.Parameters.Add(new SqlParameter("@idPersona", id));
            createUser.CommandType = CommandType.StoredProcedure;
            userConnection.Open();

            return createUser.ExecuteNonQuery();
             */
            return 0;
        }

        public int crearCliente(Cliente cliente)
        {
            /*SqlCommand createClient = new SqlCommand("FSOCIETY.sp_crear_cliente", clientConnection);
            createClient.Parameters.Add(new SqlParameter("@telefono", cliente.telefono));
            createClient.Parameters.Add(new SqlParameter("@mail", cliente.mail));
            createClient.Parameters.Add(new SqlParameter("@codigoPostal", cliente.zipcode));
            createClient.Parameters.Add(new SqlParameter("@idCliente", cliente.idCliente));
            createClient.CommandType = CommandType.StoredProcedure;
            clientConnection.Open();

            return createClient.ExecuteNonQuery();*/
            return 0;
        }

       public int getIdcliente(Cliente cliente)
        {
            DataBaseConnector db;
            db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("Select Id from FSOCIETY.Cliente where Telefono = '" + cliente.telefono
                                            + "' and Email = '" + cliente.mail + "' and Codigo_Postal = '" + cliente.zipcode + "'");
            
            return dt.Rows[1].Field<int>(1);
        }

       public int modificarPersona(Persona persona)
       {
           /*SqlCommand updatePerson = new SqlCommand("FSOCIETY.sp_modificar_persona", personConnection);
           updatePerson.Parameters.Add(new SqlParameter("@nombre", persona.nombre));
           updatePerson.Parameters.Add(new SqlParameter("@apellido", persona.apellido));
           updatePerson.Parameters.Add(new SqlParameter("@dni", persona.dni));
           updatePerson.Parameters.Add(new SqlParameter("@direccion", persona.direccion));
           updatePerson.Parameters.Add(new SqlParameter("@fecha_nacimiento", persona.nacimiento));
           updatePerson.Parameters.Add(new SqlParameter("@id", persona.idPerson));
           updatePerson.CommandType = CommandType.StoredProcedure;
           personConnection.Open();

           return updatePerson.ExecuteNonQuery();
            * */
           return 0;
       }

       public int modificarCliente(Cliente cliente)
       {/*
           SqlCommand updateClient = new SqlCommand("FSOCIETY.sp_modificar_cliente", clientConnection);
           updateClient.Parameters.Add(new SqlParameter("@telefono", cliente.telefono));
           updateClient.Parameters.Add(new SqlParameter("@mail", cliente.mail));
           updateClient.Parameters.Add(new SqlParameter("@codigoPostal", cliente.zipcode));
           updateClient.Parameters.Add(new SqlParameter("@idCliente", cliente.idCliente));
           updateClient.CommandType = CommandType.StoredProcedure;

           return updateClient.ExecuteNonQuery();
         * */
           return 0;
       }

       public int getDNIById(Persona persona)
       {
           DataBaseConnector db;
           db = DataBaseConnector.getInstance();
           DataTable dt = db.select_query("Select DNI from FSOCIETY.Personas where DNI = '" 
                                            + persona.dni + "and Id <> " + persona.idPerson + "'");

           return dt.Rows[1].Field<int>(1);
       }

       public int getMailById(Cliente cliente)
       {
           DataBaseConnector db;
           db = DataBaseConnector.getInstance();
           DataTable dt = db.select_query("Select TOP 1 Email from FSOCIETY.Cliente where Email= '"
                                            + cliente.mail + "and Id <> " + cliente.idCliente + "'");

           return dt.Rows[1].Field<int>(1);
       }

       private String getAllClientQuery() {
           return "select per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, per.[Fecha de Nacimiento], per.Direccion, cli.Codigo_Postal, cli.Habilitado from FSOCIETY.Personas per, FSOCIETY.Cliente cli, FSOCIETY.Usuarios us where per.Id = us.IdPersona and us.Id = cli.Id";
       }

       private String getSelectClientQuery(String nombre, String apellido, String dni) {
           return getAllClientQuery() + " and Nombre like '%" + nombre + 
                                      "%' and Apellido like '%" + apellido + 
                                      "%' and DNI like '%" + dni + "%'";
       }

    }
}