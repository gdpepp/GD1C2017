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
            return db.select_query("SELECT AUTOS.Id AS IdAutos, AUTOS.IdChofer AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer, AUTOS.Patente AS Patente, MARCAS.Id AS IdMarca, MARCAS.Description AS Marca, AUTOS.IdModelo AS IdModelo, MODELOS.Description AS Modelo, AUTOS.IdTurno AS IdTurno, TURNOS.Descripcion AS Turno, AUTOS.Habilitado AS Habilitado FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id LEFT JOIN FSOCIETY.Marcas MARCAS ON MODELOS.IdMarca = MARCAS.Id");
        }

        /*
        public DataTable searchCar(String marca, String patente, String modelo, String chofer) {
            if (marca != "" || patente != "" || modelo != "" || chofer != "")
            {
                return db.select_query(getSelectCarQuery(marca, patente, modelo, chofer));
            }
            else {
                return getAllCars();
            }
                        
        } 
         */

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

        public List<Chofer> getAllDriver()
        {
            List<Chofer> choferes = new List<Chofer>();
            DataTable dt = db.select_query("SELECT CHOFER.Id AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer FROM FSOCIETY.Chofer CHOFER LEFT JOIN FSOCIETY.Personas PERSONAS on CHOFER.Id = PERSONAS.Id");

            foreach (DataRow row in dt.Rows)
            {
                choferes.Add(new Chofer(row));
            }

            return choferes;
        }

        public List<Chofer> getAllDriverFree()
        {
            List<Chofer> choferesLibres = new List<Chofer>();
            DataTable dt = db.select_query("SELECT CHOFER.Id AS IdChofer, CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer FROM FSOCIETY.Chofer CHOFER LEFT JOIN FSOCIETY.Personas PERSONAS on CHOFER.Id = PERSONAS.Id WHERE CHOFER.Habilitado = 1 and CHOFER.Id not in (SELECT AUTOS.IdChofer FROM FSOCIETY.Autos AUTOS GROUP BY AUTOS.IdChofer HAVING COUNT(DISTINCT(AUTOS.IdTurno)) = 3)");

            foreach (DataRow row in dt.Rows)
            {
                choferesLibres.Add(new Chofer(row));
            }

            return choferesLibres;
        }
        /*
        private String getAllCarQuery() {
            return "SELECT CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer, AUTOS.Patente AS Patente, MARCAS.Description AS Marcas, MODELOS.Description AS Modelo, TURNOS.Descripcion AS Turno FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id LEFT JOIN FSOCIETY.Marcas MARCAS ON MODELOS.IdMarca = MARCAS.Id WHERE";
        }

        private String getSelectCarQuery(String marca, String patente, String modelo, String chofer) {
            return getAllCarQuery() + " and Marcas like '%" + marca + 
                                      "%' and Patente like '%" + patente + 
                                      "%' and Modelo like '%" + modelo +
                                      "%' and Chofer like '%" + chofer + "%'";
       }
        */
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
        /*
        public int modificarAuto(Auto auto)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@marca", auto.marca);
            dic.Add("@modelo", auto.modelo);
            dic.Add("@patente", auto.patente);
            dic.Add("@turno", auto.turno);
            dic.Add("@chofer", auto.chofer);
            dic.Add("@habilitado", auto.habilitado);

            db.executeProcedureWithParameters("FSOCIETY.sp_modificar_auto", dic);

            return 0;
        }
        */

        public int patenteExist(Auto auto)
        {
            DataTable dt = db.select_query("SELECT AUTOS.Id FROM FSOCIETY.Autos AUTOS WHERE AUTOS.Patente = '" + auto.patente + "' AND AUTOS.IdTurno ='" + auto.idTurno + "';");
            if (dt.Rows.Count > 0) 
            {
                return 1;
            }
            return 0;
        }

        public int modelOrBrandDifferent(Auto auto)
        {
            DataTable dt = db.select_query("SELECT AUTOS.Id FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id WHERE AUTOS.Patente = '" + auto.patente + "' AND MODELOS.Description = '" + auto.modelo + "' AND MODELOS.IdMarca = '" + auto.idMarca + "';");
            if (dt.Rows.Count == 0)
            {
                return 1;
            }
            return 0;
        }

        internal void deleteAuto(DataGridViewRow unAuto)
        {
            Int32 idAuto = (int)unAuto.Cells["IdAutos"].Value;
            Int32 idModelo = (int)unAuto.Cells["IdModelo"].Value;
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@idAuto", idAuto);
            dic.Add("@idModelo", idModelo);
            db.executeProcedureWithParameters("FSOCIETY.sp_eliminar_auto", dic);
        }
    }
}
