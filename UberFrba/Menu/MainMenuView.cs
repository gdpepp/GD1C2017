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
using UberFrba.Abm_Automovil;
using UberFrba.Dao;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Cliente;
using System.Reflection;
using UberFrba.Utils;

namespace UberFrba.Menu
{
    public partial class MainMenuView : Form
    {
        private Usuario user;
        private List<Funcionalidades> functions;
        private UserLogin userLoged;
        private MenuStrip menu;

        public MainMenuView() {
            InitializeComponent();
            this.userLoged = UserLogin.getInstance();
            this.menu = new MenuStrip();
        }

        private void setupFunctions()
        {
            DAOFuncionalidades dao = new DAOFuncionalidades();
            this.functions = dao.getFunctionsByRol(user.getRol());
        }

        private void setupMenu()
        {
            this.IsMdiContainer = true;
            this.Controls.Add(menu);
            createFileItem();
            createParentIntems();
            this.MainMenuStrip = menu;
        }

        private ToolStripMenuItem createSubMenuItems(Funcionalidades f)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(f.getDescription(), null, new EventHandler(ChildClick),f.getFormName());
            return item;
        }

        private ToolStripMenuItem createMenuItems(String name)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name);
            return item;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.user = userLoged.User;
            if (user == null)
            {
                LoginView view = new LoginView(this);
                this.Hide();
                view.ShowDialog();
            }
            else {
                setupFunctions();
                setupMenu(); 
            }
        }

        public void reload() {
            this.user = UserLogin.getInstance().User;
            setupFunctions();
            setupMenu(); 

        }

        private void createParentIntems()
        {
            List<Funcionalidades> func = functions.Where(item => item.getParent() == "").ToList();
            foreach (Funcionalidades f in func)
            {
                ToolStripMenuItem parent = createMenuItems(f.getDescription());
                createChildrenItems(f, parent);
                this.menu.Items.Add(parent);
            }
        }

        private void createChildrenItems(Funcionalidades f, ToolStripMenuItem parent) {
            List<Funcionalidades> func = functions.Where(item => item.getParent() == f.getDescription()).ToList();
            foreach(Funcionalidades f2 in func){
                parent.DropDownItems.Add(createSubMenuItems(f2));
            }
        }

        private void ChildClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (ToolStripMenuItem)sender;
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            foreach (Type type in frmAssembly.GetTypes())
            {
                
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == tool.Name)
                    {
                        Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());

                        foreach (Form form in this.MdiChildren)
                        {
                            form.Close();
                        }

                        frmShow.MdiParent = this;
                        frmShow.WindowState = FormWindowState.Maximized;
                        //frmShow.ControlBox = false;
                        frmShow.Show();
                    }
                }
            }
        }

        private void closeApp(object sender, EventArgs e) {
            Application.Exit();
        }


        private void createFileItem() {
            ToolStripMenuItem exit = createMenuItems("Archivo");
            exit.DropDownItems.Add(createLoginItem());
            exit.DropDownItems.Add(createExitItem());
            this.menu.Items.Add(exit);
        }

        private ToolStripMenuItem createExitItem()
        {
            return new ToolStripMenuItem("Salir", null, new EventHandler(closeApp));
        }

        private ToolStripMenuItem createLoginItem() {
            if(userLoged.User == null){
                return new ToolStripMenuItem("Iniciar Sesión", null, new EventHandler(closeApp));
            }else{
                return new ToolStripMenuItem("Cambiar usuario", null, new EventHandler(closeApp));
            }
            
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void setupForm(){
            this.IsMdiContainer = true;
            this.Controls.Add(menu);
            createParentIntems();
            this.MainMenuStrip = menu;
        }
    }
}
