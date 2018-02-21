using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dllReporte
{
    public partial class Visualizador : Form
    {
        public Visualizador()
        {
            InitializeComponent();
        }

        //Método que imprime el reporte a una impresora fisica o archivo
        public void setReport(string st)
        {

            try
            {
                ReportDocument j = new ReportDocument();
                j.Load(st);
                j.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception crex) { MessageBox.Show(crex.Message); }


        }

        //Método que muestra el reporte por CrystalReports
        public void mostrarReportes(string st)
        {
            try
            {
                this.crystalReportViewer1.ReportSource = st;
            }
            catch (CrystalReportsException xe) { MessageBox.Show(xe.Message); }
            catch (Exception crex) { MessageBox.Show(crex.Message); }

        }
    }
}
