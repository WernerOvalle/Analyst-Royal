using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Navegador.Utilidades;

namespace PRUEBA_NAVEGADOR1
{
    public partial class Form1 : Form
    {

        //OdbcCommand com;
        //OdbcDataReader dr;
        conexion con = new conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.comprobacionConexion())
            {
                //SI LA CONEXION ES CORRECTA NO HACE NADA, SIGUE CON LA EJECUCION
                MessageBox.Show("Conexion Exitosa");
            }
            else
            {
                MessageBox.Show("Error en Conexion");
            }
        }

        private void navegador1_RecibidorInsertar(object sender, EventArgs e)
        {
            string bd = navegador1.sNombreBD;
            string server = navegador1.sServidor;
            string user = navegador1.sUsuario;
            string pass = navegador1.sPass;
            string nametabla = navegador1.sNombreTabla;

            String campo1 = textBox1.Text;
            String campo2 = textBox2.Text;
            String campo3 = textBox3.Text;
            String campo4 = textBox9.Text;
            String campo5 = textBox8.Text;

            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();

            listacampos.Add(textBox1.Tag.ToString());
            listacampos.Add(textBox2.Tag.ToString());
            listacampos.Add(textBox3.Tag.ToString());
            listacampos.Add(textBox9.Tag.ToString());
            listacampos.Add(textBox8.Tag.ToString());

            listavalores.Add(campo1);
            listavalores.Add(campo2);
            listavalores.Add(campo3);
            listavalores.Add(campo4);
            listavalores.Add(campo5);
            //listavalores.Add(campo6);

            GeneradorSQL gsql = new GeneradorSQL(server, bd, user, pass, nametabla);
            gsql.setCodigoInstDML(1);
            gsql.setCampos(listacampos);
            gsql.setValores(listavalores);
            gsql.ejecutar();
        }

        private void navegador1_RecibidorEliminar(object sender, EventArgs e)
        {
            string bd = navegador1.sNombreBD;
            string server = navegador1.sServidor;
            string user = navegador1.sUsuario;
            string pass = navegador1.sPass;
            string nametabla = navegador1.sNombreTabla;

            String campo1 = textBox1.Text;
            String campo2 = textBox2.Text;
            String campo3 = textBox3.Text;
            String campo4 = textBox9.Text;
            String campo5 = textBox8.Text;


            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();

            listacampos.Add(textBox1.Tag.ToString());

            listavalores.Add(campo1);



            GeneradorSQL gsql = new GeneradorSQL(server, bd, user, pass, nametabla);
            gsql.setCodigoInstDML(3);
            gsql.setComparacion(textBox1.Tag.ToString(), campo1);
            gsql.ejecutar();
        }

        private void navegador1_RecibidorActualizar(object sender, EventArgs e)
        {
            string bd = navegador1.sNombreBD;
            string server = navegador1.sServidor;
            string user = navegador1.sUsuario;
            string pass = navegador1.sPass;
            string nametabla = navegador1.sNombreTabla;

            String campo1 = textBox1.Text;
            String campo2 = textBox2.Text;
            String campo3 = textBox3.Text;
            String campo4 = textBox8.Text;
            String campo5 = textBox9.Text;

            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();

            listacampos.Add(textBox1.Tag.ToString());
            listacampos.Add(textBox2.Tag.ToString());
            listacampos.Add(textBox3.Tag.ToString());
            listacampos.Add(textBox8.Tag.ToString());
            listacampos.Add(textBox9.Tag.ToString());

            listavalores.Add(campo1);
            listavalores.Add(campo2);
            listavalores.Add(campo3);
            listavalores.Add(campo4);
            listavalores.Add(campo5);


            GeneradorSQL gsql = new GeneradorSQL(server, bd, user, pass, nametabla);
            gsql.setCodigoInstDML(2);
            gsql.setCampos(listacampos);
            gsql.setValores(listavalores);
            gsql.setComparacion(textBox1.Tag.ToString(), campo1);

            gsql.ejecutar();
        }
    }
}

