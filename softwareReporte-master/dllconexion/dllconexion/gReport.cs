using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace dllconexion
{
    public static class gReport
    {
        private static string db_user = "";  /* Variables para establecer conexión a la base de datos */
        private static string db_pass = "";
        private static string db_srv = "";
        private static string db_name = "";

        private static int idApp = 0; //Variable para almacenar en codigo de módulo o aplicación

        public static void cargarReporte(int codApp, int vista)
        {
            conectar con = new conectar();
            if (con.OpenConnection())
            {
                System.Windows.Forms.MessageBox.Show("Reporte ---> " + codApp.ToString());
                con.selectReporte(codApp, vista);
                con.CloseConnection();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error de conexión de base de datos", "gReports");
            }
        }

        /*-----------------------------------------------------------------------------------------------------------------------------
         * -------------------- Propiedades de la clase gReport para establecer credenciales para la base de datos --------------------
           ----------------------------------------------------------------------------------------------------------------------------
        */        

        public static int AppId // Propiedad AppId para establecer el id de la aplicacion
        {
            get { return idApp; }
            set { idApp = value; }
        }

        public static string dbServer //Propiedad dbServer para establecer el servidor de la base de datos
        {
            get { return db_srv; }
            set { db_srv = value; }
        }

        public static string dbUser //Propiedad dbUser para establecer el usuario de la base de datos
        {
            get { return db_user; }
            set { db_user = value; }
        }

        public static string dbPass //Propiedad dbPass para establecer la contraseña de la base de datos
        {
            get { return db_pass; }
            set { db_pass = value; }
        }

        public static string dbName //Propiedad dbName para establecer el nombre de la base de datos
        {
            get { return db_name; }
            set { db_name = value; }
        }

        public static string obtenerParametrosDB() { //Método alterno para obtener parámetros de base de datos
            return "server=" + db_srv + ";user=" + db_user + ";database=" + db_name + ";password=" + db_pass;
        }

        public static void establecerParametrosDB(string dbServer, string dbUser, string dbName, string dbPass)
        {   //Método alterno para establecer parámetros de base de datos
            db_user = dbUser;
            db_pass = dbPass;
            db_srv = dbServer;
            db_name = dbName;
        }
    }
}
