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
            this.button2.BackColor = Color.FromName("DimGray");
            button3.Enabled = false;
            this.button3.BackColor = Color.FromName("DimGray");
            button5.Enabled = false;
            this.button5.BackColor = Color.FromName("DimGray");
            button6.Enabled = false;
            this.button6.BackColor = Color.FromName("DimGray");
            insert = new INSERCION(sNombreTabla);
            insert.empezandosql();
            insert.action();
            if (this.NavInsertar != null)
                this.NavInsertar(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            this.button1.BackColor = Color.FromName("DimGray");
            button3.Enabled = false;
            this.button3.BackColor = Color.FromName("DimGray");
            button5.Enabled = false;
            this.button5.BackColor = Color.FromName("DimGray");
            button6.Enabled = false;
            this.button6.BackColor = Color.FromName("DimGray");
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
            this.button1.BackColor = Color.FromName("DimGray");
            button2.Enabled = false;
            this.button2.BackColor = Color.FromName("DimGray");
            delete = new ELIMINAR(sNombreTabla);
            delete.empezandosql();
            delete.action();
            if (this.NavEliminar != null)
                this.NavEliminar(this, e);
        }
        
        private void button7_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            this.button1.BackColor = Color.FromName("Transparent");
            button2.Enabled = true;
            this.button2.BackColor = Color.FromName("Transparent");
            button3.Enabled = true;
            this.button3.BackColor = Color.FromName("Transparent");
            button4.Enabled = true;
            this.button4.BackColor = Color.FromName("Transparent");
            button5.Enabled = true;
            this.button5.BackColor = Color.FromName("Transparent");
            button6.Enabled = true;
            this.button6.BackColor = Color.FromName("Transparent");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.NavAyuda != null)
                this.NavAyuda(this, e);
            Process.Start("Navegadorfinal\\Navegador_Manual.chm");
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.NavSalir != null)
                this.NavSalir(this, e);
        }
    }
}



