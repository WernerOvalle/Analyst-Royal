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
using Navegador;
using Navegador.Utilidades;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            

            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();


            listacampos.Add(textBox1.Tag.ToString());


            listavalores.Add(campo1);

            listacampos.Add(textBox2.Tag.ToString());


            listavalores.Add(campo2);



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

            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();


            listacampos.Add(textBox2.Tag.ToString());


            listavalores.Add(campo2);


            GeneradorSQL gsql = new GeneradorSQL(server, bd, user, pass, nametabla);
            gsql.setCodigoInstDML(2);
            gsql.setCampos(listacampos);
            gsql.setValores(listavalores);
            gsql.setComparacion(textBox1.Tag.ToString(), campo1);
            gsql.ejecutar();

        }

        private void navegador1_Load(object sender, EventArgs e)
        {

        }
    }
}
