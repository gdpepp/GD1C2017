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
using UberFrba.Mapping;

namespace UberFrba.Dao
{
    class DAOAutomovil
    {
        public DataTable getAllCars()
        {
            DataBaseConnector db = DataBaseConnector.getInstance();
            return db.select_query("SELECT CONCAT(PERSONAS.Apellido,' ',PERSONAS.Nombre) AS Chofer, AUTOS.Patente AS Patente, MARCAS.Description AS Marcas, MODELOS.Description AS Modelo, TURNOS.Descripcion AS Turno FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id LEFT JOIN FSOCIETY.Marcas MARCAS ON MODELOS.IdMarca = MARCAS.Id"); 
        }

        public List<Marca> getAllBrands()
        {
            List<Marca> marcas = new List<Marca>();
            DataBaseConnector db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("SELECT MARCAS.id,MARCAS.Description FROM FSOCIETY.Marcas MARCAS");

            foreach (DataRow row in dt.Rows)
            {
                marcas.Add(new Marca(row));
            }

            return marcas;
        }
    }
}
