using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Mapping;
using UberFrba.Dao;

namespace UberFrba.Menu
{
    public partial class MainMenu : Form
    {
        private Usuario user;
        private List<Funcionalidades> functions;

        public MainMenu(Object user)
        {
            this.user = (Usuario)user;
            setupFunctions();
            InitializeComponent();
            this.label1.Text = "Bienvenido " + this.user.getUsername() + " con perfil: " + this.user.getRol().getDescription();
        }

        private void setupFunctions(){
            DaoFuncionalidades dao = new DaoFuncionalidades();
            this.functions = dao.getFunctionsByRol(user.getRol());
        }

        private void setupMenu(){
           
        }
    }
}
