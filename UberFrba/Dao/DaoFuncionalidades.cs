﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;

namespace UberFrba.Dao
{
    class DaoFuncionalidades
    {
        public List<Funcionalidades> getFunctionsByRol(Rol rol) {
            List<Funcionalidades> functions = new List<Funcionalidades>();
            DataBaseConnector db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("Select f.Id,f.Descripcion,f.Padre from FSOCIETY.RolFuncionalidades as rf join FSOCIETY.Funcionalidades as f on rf.IdFuncionalidad = f.Id where rf.IdRol = '" + rol.getId() + "'");

            foreach (DataRow row in dt.Rows)
            {
                functions.Add(new Funcionalidades(row));
            }

            return functions;
        }

    }
}
