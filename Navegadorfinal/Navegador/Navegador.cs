using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
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
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            insert = new INSERCION(sNombreTabla);
            insert.empezandosql();
            if (this.NavInsertar != null)
                this.NavInsertar(this, e);





        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            update = new ACTUALIZAR(sNombreTabla);
            update.empezandosql();
            if (this.NavActualizar != null)
                this.NavActualizar(this, e);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.NavGuardar != null)
                this.NavGuardar(this, e);

            con = new Conector(sServidor, sNombreBD, sUsuario, sPass, Globales.SQL);
            con.OpenConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            delete = new ELIMINAR(sNombreTabla);
            delete.empezandosql();
            if (this.NavEliminar != null)
                this.NavEliminar(this, e);

        }

       

        private void button7_Click_1(object sender, EventArgs e)
        {

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
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



