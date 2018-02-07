using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using dllReporte;



namespace dllconexion
{
    public class conectar
    {

        private MySqlConnection cone;


        //private MySqlConnection cone;

        public conectar()
        {
            
        }
        ~conectar() {
            
        }

        //open connection to database
       public bool OpenConnection()
        {
            string myString = gReport.obtenerParametrosDB();
            cone = new MySqlConnection(myString);
            try
            {
                cone.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,"Conexión Mysql");  
            }
                return false;
            }
       public bool CloseConnection()
        {
            try
            {
                cone.Close();
                cone.Dispose();
                
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al cerrar conexion");
                return false;
            }
        }

        public DataTable llenarDataGridView(String sentencia)
        {//metodo para añadir datos a un objeto de DataTable y retornarlo
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex) { System.Windows.Forms.MessageBox.Show(ex.Message); return null; }
        }

        public void selectReporte(int codApp, int vista) /* Método para seleccionar reporte dependiendo el parámtro de codigo
                                                          * de aplicación(codApp) y el entero de tipo de vista(vista) */
        {
            string queryReport = "select path from reporteador where idReporte = '" + codApp + "' ";
            string rpt = "";
           
            try
            {
                DataTable dt = llenarDataGridView(queryReport);
                
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] != null) {
                        
                        rpt = row[0].ToString();
                    }
                }
                if( !rpt.Equals("")) {
                    Visualizador vReporte = new Visualizador();
                    if(vista == 1)
                    {
                        try
                        {
                            vReporte.mostrarReportes(rpt);
                            vReporte.Show();
                        }
                        catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
                    }
                    if(vista == 0)
                    {
                        try
                        {
                            vReporte.setReport(rpt);
                        }
                        catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
                    }
                }

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


    }
    }

