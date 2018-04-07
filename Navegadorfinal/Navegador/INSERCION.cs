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
namespace Navegador
{
    static class Globales
    {
        public static string SQL;
        public static string AccionBoton;
        public static string localIP;
    }

    public class INSERCION
    {
        private string nombreTabla;

        public INSERCION()
        {
        }

        public INSERCION(string tabla)
        {
            this.nombreTabla = tabla;
        }

        public void action()
        {
            Globales.AccionBoton = "";
            Globales.AccionBoton = "Insertar"; 
        }

        public void empezandosql()
        {
            Globales.SQL = "INSERT INTO " + this.nombreTabla + "(";
        }

        public void CREANDOSQL(string dato)
        {
            if (dato != string.Empty)
            {
                Globales.SQL += "" + dato + ",";
            }
        }

        public void coma()
        {
            Globales.SQL = Globales.SQL.Remove(Globales.SQL.Length - 1);
            Globales.SQL += ");";
        }

        public void value()
        {
            Globales.SQL = Globales.SQL.Remove(Globales.SQL.Length - 1);
            Globales.SQL += " )VALUES (";
        }

        public void CREANDOSQL2(string dato)
        {
            if (dato != string.Empty)
            {
                long number1 = 0;
                bool canConvert = long.TryParse(dato, out number1);
                if (canConvert == true) { Globales.SQL += "" + number1 + ","; }
                else { Globales.SQL += "'" + dato + "',"; }
            }
        }
    }
}