using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UberFrba.Utils;
using System.Data.SqlClient;
using WindowsFormsApplication1;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Abm_Automovil;

namespace UberFrba.Dao
{
    class DAOAutomovil
    {
        private DataBaseConnector db;

        public DAOAutomovil() {
            this.db = DataBaseConnector.getInstance();
        }

        public DataTable getAllCars()
        {
            return db.select_query("SELECT AUTOS.Id AS IdAutos, AUTOS.IdChofer AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer, AUTOS.Patente AS Patente, MARCAS.Id AS IdMarca, MARCAS.Description AS Marca, AUTOS.IdModelo AS IdModelo, MODELOS.Description AS Modelo, AUTOSTURNOS.IdTurno AS IdTurno, TURNOS.Descripcion AS Turno, AUTOS.Habilitado AS Habilitado FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.AutosTurnos AUTOSTURNOS ON AUTOS.Id = AUTOSTURNOS.IdAuto LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOSTURNOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id LEFT JOIN FSOCIETY.Marcas MARCAS ON MODELOS.IdMarca = MARCAS.Id");
        }

 
        public DataTable searchCar(String marca, String patente, String modelo, String chofer) {
            if (marca != "" || patente != "" || modelo != "" || chofer != "")
            {
                return db.select_query(getSelectCarQuery(marca, patente, modelo, chofer));
            }
            else {
                return getAllCars();
            }                        
        }

        private String getAllCarQuery() {
            return "SELECT AUTOS.Id AS IdAutos, AUTOS.IdChofer AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer, AUTOS.Patente AS Patente, MARCAS.Id AS IdMarca, MARCAS.Description AS Marca, AUTOS.IdModelo AS IdModelo, MODELOS.Description AS Modelo, AUTOSTURNOS.IdTurno AS IdTurno, TURNOS.Descripcion AS Turno, AUTOS.Habilitado AS Habilitado FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.AutosTurnos AUTOSTURNOS ON AUTOS.Id = AUTOSTURNOS.IdAuto LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOSTURNOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id LEFT JOIN FSOCIETY.Marcas MARCAS ON MODELOS.IdMarca = MARCAS.Id WHERE AUTOS.Id != ''";
        }

        private String getSelectCarQuery(String marca, String patente, String modelo, String chofer) {
            return getAllCarQuery() + " AND MARCAS.Description LIKE '%" + marca +
                                      "%' AND AUTOS.Patente LIKE '%" + patente +
                                      "%' AND MODELOS.Description LIKE '%" + modelo +
                                      "%' AND (PERSONAS.Apellido LIKE '%" + chofer + 
                                      "%' OR PERSONAS.Nombre LIKE '%" + chofer + "%')";
       }

        public List<Marca> getAllBrands()
        {
            List<Marca> marcas = new List<Marca>();
            DataTable dt = db.select_query("SELECT MARCAS.id AS IdMarca,MARCAS.Description AS Marca FROM FSOCIETY.Marcas MARCAS");

            foreach (DataRow row in dt.Rows)
            {
                marcas.Add(new Marca(row));
            }

            return marcas;
        }

        public List<Turno> getAllTurn()
        {
            List<Turno> turnos = new List<Turno>();
            DataTable dt = db.select_query("SELECT TURNOS.Id AS IdTurno, TURNOS.Descripcion AS Turno FROM FSOCIETY.Turnos TURNOS;");

            foreach (DataRow row in dt.Rows)
            {
                turnos.Add(new Turno(row));
            }

            return turnos;
        }

        internal List<Turno> getAllTurnFree(DataGridViewRow unAuto, Chofer_Auto unChofer)
        {
            List<Turno> turnos = new List<Turno>();
            if (unChofer != null)
            {
                DataTable dt = db.select_query("SELECT TURNOS.Id AS IdTurno, TURNOS.Descripcion AS Turno FROM FSOCIETY.Turnos TURNOS WHERE TURNOS.Id NOT IN (SELECT TURNOS.Id FROM FSOCIETY.Turnos TURNOS INNER JOIN FSOCIETY.AutosTurnos AUTOSTURNOS ON TURNOS.Id = AUTOSTURNOS.IdTurno INNER JOIN FSOCIETY.Autos AUTOS ON AUTOSTURNOS.IdAuto = AUTOS.Id WHERE AUTOS.IdChofer = '" + unChofer.getId() + "')");

                foreach (DataRow row in dt.Rows)
                {
                    turnos.Add(new Turno(row));
                }

                if (unAuto != null)
                {
                    turnos.Add(new Turno(unAuto));
                }
            }
            return turnos;
        }

        public List<Chofer_Auto> getAllDriver()
        {
            List<Chofer_Auto> choferes = new List<Chofer_Auto>();
            DataTable dt = db.select_query("SELECT CHOFER.Id AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer FROM FSOCIETY.Chofer CHOFER LEFT JOIN FSOCIETY.Personas PERSONAS on CHOFER.Id = PERSONAS.Id");

            foreach (DataRow row in dt.Rows)
            {
                choferes.Add(new Chofer_Auto(row));
            }

            return choferes;
        }

        public List<Chofer_Auto> getAllDriverFree(DataGridViewRow unAuto)
        {
            List<Chofer_Auto> choferesLibres = new List<Chofer_Auto>();
            DataTable dt = db.select_query("SELECT CHOFER.Id AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer FROM FSOCIETY.Chofer CHOFER LEFT JOIN FSOCIETY.Personas PERSONAS on CHOFER.Id = PERSONAS.Id WHERE CHOFER.Habilitado = 1 and CHOFER.Id not in (SELECT AUTOS.IdChofer FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.AutosTurnos AUTOSTURNOS ON AUTOS.Id = AUTOSTURNOS.IdAuto GROUP BY AUTOS.IdChofer HAVING COUNT(AUTOSTURNOS.IdAuto) = 3)");

            foreach (DataRow row in dt.Rows)
            {
                choferesLibres.Add(new Chofer_Auto(row));
            }

            if (unAuto != null)
            {
                choferesLibres.Add(new Chofer_Auto(unAuto));
            }

            return choferesLibres;
        }

        public void crearAuto(Auto auto)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idMarca", auto.idMarca);
            dic.Add("@modelo", auto.modelo);
            dic.Add("@patente", auto.patente);
            dic.Add("@idTurno", auto.idTurno);
            dic.Add("@idChofer", auto.idChofer);
            dic.Add("@habilitado", auto.habilitado);

            db.executeProcedureWithParameters("FSOCIETY.sp_crear_auto", dic);
        }

        public int carExists(Auto auto)
        {
            DataTable dt = db.select_query("SELECT AUTOS.Id FROM FSOCIETY.Autos AUTOS WHERE AUTOS.Patente = '" + auto.patente + "';");
            if (dt.Rows.Count != 0)
            {
                return 1;
            }
            return 0;
        }

        internal void deleteAuto(DataGridViewRow unAuto)
        {
            Int32 idAuto = (int)unAuto.Cells["IdAutos"].Value;
            Int32 idModelo = (int)unAuto.Cells["IdModelo"].Value;
            Int32 idTurno = (int)unAuto.Cells["IdTurno"].Value;
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idAuto", idAuto);
            dic.Add("@idModelo", idModelo);
            dic.Add("@idTurno", idTurno);
            db.executeProcedureWithParameters("FSOCIETY.sp_eliminar_auto", dic);
        }

        internal void createTurno(DataGridViewRow unAuto, Turno turno)
        {
            Int32 idAuto = (int)unAuto.Cells["IdAutos"].Value;
            Int32 idTurno = turno.getId();
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idAuto", idAuto);
            dic.Add("@idTurno", idTurno);
            db.executeProcedureWithParameters("FSOCIETY.sp_agregar_turno", dic);
        }

        internal void updateAuto(Auto auto, Turno turnoViejo)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idAuto", auto.idAuto);
            dic.Add("@idModelo", auto.idModelo);
            dic.Add("@idMarca", auto.idMarca);
            dic.Add("@modelo", auto.modelo);
            dic.Add("@patente", auto.patente);
            dic.Add("@idTurno", auto.idTurno);
            dic.Add("@idChofer", auto.idChofer);
            dic.Add("@habilitado", auto.habilitado);
            dic.Add("@idTurnoViejo", turnoViejo.getId());

            db.executeProcedureWithParameters("FSOCIETY.sp_actualizar_auto", dic);
        }
    }
}
