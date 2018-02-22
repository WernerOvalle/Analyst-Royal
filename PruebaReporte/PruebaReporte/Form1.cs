using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdministradorDeReportes;
using dllReporte;
namespace PruebaReporte
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void navegador1_Load(object sender, EventArgs e)
        {

        }

        private void vistaPreviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navegador1.VistaReporte = 1;         
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navegador1.VistaReporte = 0;
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministradorDeReportes.Objetos.dbConexion.dbName = "pruebareportes";
            AdministradorDeReportes.Objetos.dbConexion.dbServer = "127.0.0.1";
            AdministradorDeReportes.Objetos.dbConexion.dbUser = "root";
            AdministradorDeReportes.Objetos.dbConexion.dbPass = "";
            Mantenimiento mant = new Mantenimiento();
            mant.Show();
        }

        private void listadoDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Form1.numeroAplicacion = Convert.ToInt16(textBox1.text);
                dllconexion.gReport.establecerParametrosDB("127.0.0.1", "root", "pruebareportes", "");
                dllconexion.seleccionPath lista = new dllconexion.seleccionPath(navegador1.IdApp, 0);
                lista.Show();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Reportes");
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
