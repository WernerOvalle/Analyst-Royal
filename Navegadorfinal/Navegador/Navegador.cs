using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;


namespace Navegador
{
    public partial class Navegador : UserControl
    {
        [Description("Direccion servidor")]
        [Category("ParametrosBD")]
        public String sServidor { get; set; }
        [Description("BaseDatos")]
        [Category("ParametrosBD")]
        public String sNombreBD { get; set; }
        [Description("NombreTabla")]
        [Category("ParametrosBD")]
        public String sNombreTabla { get; set; }
        [Description("Usuario")]
        [Category("ParametrosBD")]
        public String sUsuario { get; set; }
        [Description("Contraseña")]
        [Category("ParametrosBD")]
        public String sPass { get; set; }
        [Description("Num App")]
        [Category("ParametrosBD")]
        public String sAppNumero { get; set; }
        [Description("Nom usuario")]
        [Category("ParametrosBD")]
        public String sNom_Usuario { get; set; }
        private Conector con;
        private INSERCION insert;
        private ACTUALIZAR update;
        private ELIMINAR delete;

        public event EventHandler NavInsertar;
        public event EventHandler NavActualizar;
        public event EventHandler NavEliminar;
        public event EventHandler NavGuardar;
        public event EventHandler NavInicio;
        public event EventHandler NavAnterior;
        public event EventHandler NavSiguiente;
        public event EventHandler NavFin;
        public event EventHandler NavAyuda;
        public event EventHandler NavSalir;

        public Navegador()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Image = Properties.Resources._2;
            button3.Enabled = false;
            button3.Image = Properties.Resources._3;
            button5.Enabled = false;
            button5.Image = Properties.Resources._10;
            button6.Enabled = false;
            button6.Image = Properties.Resources._11;
            button4.Enabled = true;
            button4.Image = Properties.Resources.icons8_Save_48px;
            button7.Enabled = true;
            button7.Image = Properties.Resources.icons8_Cancel_48px;

            insert = new INSERCION(sNombreTabla);
            insert.empezandosql();
            insert.action();
            if (this.NavInsertar != null)
                this.NavInsertar(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Image = Properties.Resources._1;
            button3.Enabled = false;
            button3.Image = Properties.Resources._3;
            button5.Enabled = false;
            button5.Image = Properties.Resources._10;
            button6.Enabled = false;
            button6.Image = Properties.Resources._11;
            button4.Enabled = true;
            button4.Image = Properties.Resources.icons8_Save_48px;
            button7.Enabled = true;
            button7.Image = Properties.Resources.icons8_Cancel_48px;

            update = new ACTUALIZAR(sNombreTabla);
            update.empezandosql();
            update.action();
            if (this.NavActualizar != null)
                this.NavActualizar(this, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (this.NavGuardar != null)
                this.NavGuardar(this, e);
            con = new Conector(sServidor, sNombreBD, sUsuario, sPass, sAppNumero, Globales.SQL, Globales.AccionBoton, sNom_Usuario);
            con.OpenConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Image = Properties.Resources._1;
            button2.Enabled = false;
            button2.Image = Properties.Resources._2;
            button5.Enabled = false;
            button5.Image = Properties.Resources._10;
            button6.Enabled = false;
            button6.Image = Properties.Resources._11;
            button4.Enabled = true;
            button4.Image = Properties.Resources.icons8_Save_48px;
            button7.Enabled = true;
            button7.Image = Properties.Resources.icons8_Cancel_48px;

            delete = new ELIMINAR(sNombreTabla);
            delete.empezandosql();
            delete.action();
            if (this.NavEliminar != null)
                this.NavEliminar(this, e);
        }
        
        private void button7_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Image = Properties.Resources.icons8_Add_File_48px;
            button2.Enabled = true;
            button2.Image = Properties.Resources.icons8_Edit_File_48px;
            button3.Enabled = true;
            button3.Image = Properties.Resources.icons8_Delete_File_48px;
            button5.Enabled = true;
            button5.Image = Properties.Resources.icons8_Search_48px;
            button6.Enabled = true;
            button6.Image = Properties.Resources.icons8_Print_48px;
            button7.Enabled = true;
            button7.Image = Properties.Resources.icons8_Cancel_48px;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.NavAyuda != null)
                this.NavAyuda(this, e);
            Process.Start("Navegadorfinal\\Navegador_Manual.chm");
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button4.Image  = Properties.Resources.icons8_Save_48px;
            button7.Enabled = false;
            button7.Image = Properties.Resources.icons8_Cancel_48px; 

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.NavSalir != null)
                this.NavSalir(this, e);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.NavInicio != null)
                this.NavInicio(this, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.NavAnterior != null)
                this.NavAnterior(this, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.NavSiguiente != null)
                this.NavSiguiente(this, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.NavFin != null)
                this.NavFin(this, e);
        }
    }
}



