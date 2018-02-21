using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using dllReporte;

namespace dllconexion
{
    public partial class seleccionPath : Form
    {
        private static int numero;
        private static int rVista;
        private static string fileReport;
        private dllconexion.conectar connection = new dllconexion.conectar();

        public seleccionPath(int numApp, int iVista)
        {
            numero = numApp;
            rVista = iVista;
            InitializeComponent();
            initDatagridviewData();
        }


        public void codAplicacion()
        {
            
            if (connection.OpenConnection()) {
                dataGridView1.DataSource = connection.llenarDataGridView("select * from reporte where codigoAplicacion = '" + numero + "'");
                agregarCheckbox();
                connection.CloseConnection();
            }
            else
            {

            }
        }


        public string archivo_;
        void agregarCheckbox()
        {
            dataGridView1.AutoGenerateColumns = false;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(chk);
                chk.HeaderText = "IMPRIMIR";
                chk.Name = "IMPRIMIR";
        }

        private void initDatagridviewData()
        {
            try
            {
                dllconexion.conectar conn = new dllconexion.conectar();
                conn.OpenConnection();
                dataGridView1.DataSource = conn.llenarDataGridView("select idReporteg as ID, nombreReporteg as Nombre, pathr as path from reportegeneral where reporte_app_id = '" + numero + "'");
                agregarCheckbox();
                conn.CloseConnection();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Listado de Reportes"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
           // MessageBox.Show(headerText);
            string nombreColumna2 = "IMPRIMIR";
            string nombreColumna = "path";

            try
            {

                var columnList = dataGridView1.Columns.Cast<DataGridViewColumn>().ToList();
                int inde = columnList.FindIndex(c => c.HeaderText == nombreColumna);

                var columnImpresion = dataGridView1.Columns.Cast<DataGridViewColumn>().ToList();
                int indeImpresion = columnList.FindIndex(c => c.HeaderText == nombreColumna2);

                if (headerText.Equals(nombreColumna))

                {


                    string archivo = (dataGridView1.Rows[e.RowIndex].Cells[inde].Value.ToString());
                    fileReport = archivo;
                    //numero = (int)(dataGridView1.Rows[e.RowIndex].Cells["pathr"].Value);

                    Visualizador rptt = new Visualizador();
                    rptt.mostrarReportes(archivo);
                    rptt.Show();
                }

                else if (headerText.Equals("IMPRIMIR"))
                {

                    Visualizador rpttp = new Visualizador();
                    rpttp.setReport(fileReport);
                }
                else
                {


                    //MessageBox.Show("Seleccione la columna correcta");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


                } 

        private void seleccionPath_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(row.Cells["IMPRIMIR"].Value))
                {

                    archivo_ = (row.Cells["path"].Value.ToString());
                    Visualizador rptt = new Visualizador();
                    rptt.setReport(archivo_);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            AdministradorDeReportes.Objetos.parametros.IdApp = numero;
            AdministradorDeReportes.Objetos.dbConexion.dbName = gReport.dbName;
            AdministradorDeReportes.Objetos.dbConexion.dbServer = gReport.dbServer;
            AdministradorDeReportes.Objetos.dbConexion.dbUser = gReport.dbUser;
            AdministradorDeReportes.Objetos.dbConexion.dbPass = gReport.dbPass;
            AdministradorDeReportes.MantenimientoReporteG mante = new AdministradorDeReportes.MantenimientoReporteG();
            mante.Show();
            this.Dispose();
        }
    }
}
