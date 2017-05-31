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
            InitializeComponent();
            this.user = (Usuario)user;
            //setupFunctions();
            
        }

        private void setupFunctions()
        {
            DaoFuncionalidades dao = new DaoFuncionalidades();
            this.functions = dao.getFunctionsByRol(user.getRol());
        }

        private void setupMenu()
        {
            this.IsMdiContainer = true;
            MenuStrip MnuStrip = new MenuStrip();
            this.Controls.Add(MnuStrip);
            foreach(Funcionalidades f in functions ){
                MnuStrip.Items.Add(createMenuItems(f.getDescription()));
            }

            this.MainMenuStrip = MnuStrip;
        }

        private ToolStripMenuItem createMenuItems(String name)
        {
            return new ToolStripMenuItem(name);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            setupFunctions();
            setupMenu();

        }
    }
}
