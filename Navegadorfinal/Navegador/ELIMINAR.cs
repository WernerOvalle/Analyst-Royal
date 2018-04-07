using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navegador
{
    public class ELIMINAR
    {
        private string nombreTabla;

        public ELIMINAR()
        {
        }

        public ELIMINAR(string tabla)
        {
            this.nombreTabla = tabla;
        }

        public void action()
        {
            Globales.AccionBoton = "";
            Globales.AccionBoton = "Eliminar";
        }

        public void empezandosql()
        {
            Globales.SQL = "DELETE FROM " + this.nombreTabla + " ";
        }

        public void finalizarsql(string dato, string dato2) {
            Globales.SQL += "WHERE ";
            if (dato != string.Empty && dato2 != string.Empty)
            {
                Globales.SQL += dato2;
                long number1 = 0;
                bool canConvert = long.TryParse(dato, out number1);
                if (canConvert == true) { Globales.SQL += " = " + number1 + ";"; }
                else { Globales.SQL += " = " + dato + ";"; }
            }
        }
    }
}
