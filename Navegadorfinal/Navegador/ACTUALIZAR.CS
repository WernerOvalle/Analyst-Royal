using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navegador
{

    public class ACTUALIZAR
    {
        private string nombreTabla;
        private string where = " WHERE ";
        
        public ACTUALIZAR()
        {
        }

        public ACTUALIZAR(string tabla)
        {
            this.nombreTabla = tabla;
        }

        public void action()
        {
            Globales.AccionBoton = "";
            Globales.AccionBoton = "Editar";
        }

        public void empezandosql()
        {
            Globales.SQL = "UPDATE " + this.nombreTabla + " SET ";
        }
        
        public void coma() { Globales.SQL = Globales.SQL.Remove(Globales.SQL.Length - 1); }
        
        public void COMPARACION(string dato, string dato2)
        {
            where += dato2;
            where += '=';
            where += dato;
            where += ';';
        }
        public void finalizarsql() { Globales.SQL += where; }

        public void CREANDOSQL(string dato, string dato2)
        {
            if (dato2 != string.Empty)
            {
                Globales.SQL += dato2;
                Globales.SQL += '=';
            }
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

