using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data;

namespace PRUEBA_NAVEGADOR1
{
    class conexion
    {
        OdbcConnection con = new OdbcConnection("Driver ={ MySQL ODBC 5.3 ANSI Driver }; Dsn=pruebaNavegador; ");
        //OdbcCommand cmd;
        //OdbcDataReader dr;
        //OdbcDataAdapter da;

        public OdbcConnection Conexion()
        {

            con.Open();
            return con;
        }

        public bool comprobacionConexion()
        {
            try
            {
                Conexion();
                return true;
            }
            catch (OdbcException ex)
            {
                return false;
            }
        }
    }
}
