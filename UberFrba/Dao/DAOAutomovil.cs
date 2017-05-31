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

namespace UberFrba.Dao
{
    class DAOAutomovil
    {
        SqlConnection automovilConnection = DBConnection.getInstance().getConnection();
    }
}
