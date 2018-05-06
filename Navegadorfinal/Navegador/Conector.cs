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
using System.Net;
using dll_bitacora;

namespace Navegador
{//werner variables de conexion 
    public class Conector
    {
        private MySqlConnection conexion;
        private string sConexion, server, db, user, pass, AppNumero, SQL, AccionBoton, sNom_Usuario;

        //kimberly conexion para bitacora
        public static String stringpad = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=servidor_seguridad; UID=root; PWD = ; Database=bd_seguridad; ";
        dll_bitacora.dll_bitacora connection = new dll_bitacora.dll_bitacora(stringpad);

        public Conector()
        {
        }
        
        static class Globaless
        {
            public static string Sexito = "Exitoso";
            public static string Serror = "No";
            public static string Nexito = "No exitoso";
            public static string Nerror = "";
        }

        public void obtenerIP()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    Globales.localIP = ip.ToString();
                }
            }
        }
        //werner ovalle obtener parametros
        public Conector(string server, string db, string user, string pass, string sAppNumero, string SQL, string AccionBoton, string sNom_Usuario)
        {
            this.server = server;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.AppNumero = sAppNumero;
            this.SQL = SQL;
            this.AccionBoton = AccionBoton;
            this.sNom_Usuario = sNom_Usuario;
        }

        public static String s_error;
        //werner inicion de conexion
        public void OpenConnection()
        {
            obtenerIP(); int App_Numero = Convert.ToInt16(AppNumero);
    
            MessageBox.Show(Globales.SQL);
           
  
            sConexion = "SERVER=" + this.server + ";" + "DATABASE=" +
                this.db + ";" + "UID=" + this.user + ";" + "PASSWORD=" + this.pass + ";";
            try
            {
                MySqlConnection MyConn2 = new MySqlConnection(sConexion);
                MySqlCommand MyCommand2 = new MySqlCommand(Globales.SQL, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();       
                MessageBox.Show("Exito");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                // kimberly alejandra insert a bitacora exito
                connection.OpenConnection();
                connection.InsertarRegistro("insert into bitacora(id_usuario,fecha_bitacora,hora_bitacora,accion_usuario,id_aplicacion,resultado_bitacora,error_bitacora,ip_pc) values('" + sNom_Usuario + "', sysdate(), now(), '" + Globales.AccionBoton + "', '" + AppNumero + "','" + Globaless.Sexito + "', '" + Globaless.Serror + "','" + Globales.localIP + "')");
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                s_error = "." + ex.Message + ".";
                String[] A = s_error.Split(new char[] { '\'' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in A)
                {
                    Globaless.Nerror += i;
                }
                //kimberly alejandra insert bitacora erorr
                connection.OpenConnection();
               // connection.InsertarRegistro("insert into bitacora(id_usuario,fecha_bitacora,hora_bitacora,accion_usuario,id_aplicacion,resultado_bitacora,error_bitacora,ip_pc) values((select U.id_usuario from usuario U where U.usuario ='" + sNom_Usuario + "'), sysdate(), now(), '" + Globales.sAccionG + "', '" + app + "','" + Globales.sExitoso_n + "', '" + error_nuevo + "','" + localIP + "')");
                connection.InsertarRegistro("insert into bitacora(id_usuario,fecha_bitacora,hora_bitacora,accion_usuario,id_aplicacion,resultado_bitacora,error_bitacora,ip_pc) values('" + sNom_Usuario + "', sysdate(), now(), '" + Globales.AccionBoton + "', '" + AppNumero + "','" + Globaless.Nexito + "', '" + Globaless.Nerror + "','" + Globales.localIP + "')");
                connection.CloseConnection();
            }
        }
        // werner cerrrar conexion
        public void CloseConnection()
        {
            try
            {
                conexion.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}