using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Turno;
using UberFrba.Utils;

namespace UberFrba.Dao
{
    class DAOTurnos
    {
        private DataBaseConnector connector;

        public DAOTurnos() {
            this.connector = DataBaseConnector.getInstance();
        }

        internal void crearTurno(string desc, int inicio, int fin, string valorkm, string preciobase, bool habilitado)
        {
               Dictionary<String, Object> dic = new Dictionary<String, Object>();
                dic.Add("@Descripcion", desc);
                dic.Add("@horainicio", Convert.ToInt16(inicio));
                dic.Add("@horafin", Convert.ToInt16(fin));
                dic.Add("@valorkm", float.Parse(valorkm));
                dic.Add("@preciobase",  float.Parse(preciobase));
                dic.Add("@habilitado", habilitado);

                connector.executeProcedureWithParameters("FSOCIETY.sp_crear_turno", dic);
        }

        public bool turnoValido(int inicio, int fin, int id)
        {
            if (fin < inicio) 
            {
                MessageBox.Show("La hora de finalizacion del turno es menor a la de inicio.\n Verifique los horarios de inicio y fin","Error en datos de turno");
                return false;
            }
            if ((fin - inicio) > 24)
            {
                MessageBox.Show("el turno no puede ser mayor a 24 horas.\n Verifique los horarios de inicio y fin", "Error en datos de turno");
                return false;
            }
            if (this.solapamiento(inicio, fin, id))
            {
                MessageBox.Show("El turno a guardar se solapa con otros turnos \n Verifique los horarios de inicio y fin", "Error en datos de turno");
                return false;
            }
            return true;
        }

        public bool solapamiento(int inicio, int fin, int id)
        {
            bool result = false;
            //foreach (DataRow row in this.getAllIdsTurnos().Rows)
            //{ 
            //  int id = row.Field<int>("Id");
                if (this.horarioEnOtroTurno(inicio,id) || this.horarioEnOtroTurno(fin, id))
                {
                    result = true;
                    MessageBox.Show("Existe solapamiento de horarios.\nVerifique los datos ingresados", "Error al modificar turno");
                }
            //}
            return result;
        }

        private bool horarioEnOtroTurno(int fecha, int id)
        {
            DataTable result = connector.select_query("select Id from FSOCIETY.Turnos tur where tur.Habilitado = '1' and ('" + fecha + "' BETWEEN tur.Hora_De_Inicio and tur.Hora_De_Finalizacion) and ('" + fecha + "' <> tur.Hora_De_Inicio) and ('" + fecha + "' <> tur.Hora_De_Finalizacion)");
            if (result.Rows.Count > 0)
            {
                if (!result.Rows[0]["Id"].Equals(id))
                    return true;
                else return false;
            }
            else return false;
        }

        private DataTable getAllIdsTurnos()
        {
            return connector.select_query("select Id from FSOCIETY.Turnos");
        }

        public DataTable buscarTurnos(string descripcion)
        {
            if (descripcion != "")
            {
                return connector.select_query(getSelectTurnoQuery(descripcion));
            }
            else {
                return buscarTodosLosTurnos();
            }
        }

        public DataTable buscarTodosLosTurnos() 
        {
            return connector.select_query(getAllTurnosQuery());
        }

        private String getAllTurnosQuery()
        {
            return "select tur.Id, tur.Descripcion, tur.Hora_De_Inicio as 'Hora de Inicio', tur.Hora_De_Finalizacion as 'Hora de Finalizacion', tur.Valor_Km as 'Valor del Kilometro', tur.Precio_Base as 'Precio Base', tur.Habilitado from FSOCIETY.Turnos tur";
        }

        private String getSelectTurnoQuery(String descripcion)
        {
            return getAllTurnosQuery() + " Where tur.Descripcion like '%" + descripcion + "%'";
        }


        internal bool descripcionYaUsada(string desc, int id)
        {
            DataTable result = connector.select_query("select Id from FSOCIETY.Turnos tur where tur.Id <> '" + id + "' and tur.Descripcion = '" + desc + "' and tur.Habilitado = '1'");
           
            if (result.Rows.Count > 0)
            {
                MessageBox.Show("La descripcion ya existe.\nVerifique los datos ingresados", "Error al guardar turno");           
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void modificarturno(int id, string desc, int inicio, int fin, string valorkm, string preciobase, bool habilitado)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@id", id);
            dic.Add("@Descripcion", desc);
            dic.Add("@horainicio", Convert.ToInt16(inicio));
            dic.Add("@horafin", Convert.ToInt16(fin));
            dic.Add("@valorkm", float.Parse(valorkm));
            dic.Add("@preciobase", float.Parse(preciobase));
            dic.Add("@habilitado", habilitado);

            connector.executeProcedureWithParameters("FSOCIETY.sp_update_turno", dic);
        }

        public bool noHaceSolapar(int inicio, int fin, int idturno)
        {
            bool result = true;
            foreach (DataRow row in this.getAllIdsTurnos().Rows)
            { 
                int id = row.Field<int>("Id");
                if (this.otroHorarioEnTurno(inicio, fin, id))
                {
                    result = false;
                    MessageBox.Show("Esta modificacion hace que uno o mas horarios se solapen con este.\nVerifique los datos ingresados", "Error al modificar turno");
                }
            }
            return result;
        }

        private bool otroHorarioEnTurno(int inicio,int fin,int id)
        {
            DataTable result = connector.select_query("select Id from FSOCIETY.Turnos tur where ( tur.Hora_De_Inicio > "+ inicio +" and tur.Hora_De_Finalizacion < '" + fin + "') and tur.Id <> '" + id + "' ");
            if (result.Rows.Count > 0)
            {
                return true;
            }
             else 
            {
                return false;
            }
        }
    }
}