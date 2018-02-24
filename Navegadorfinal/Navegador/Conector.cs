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

    public class Conector

    {
        private MySqlConnection conexion;
        private string sConexion, server, db, user, pass, SQL;


        public Conector()
        {
        }

        public Conector(string server, string db, string user, string pass, string SQL)
        {
            this.server = server;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.SQL = SQL;
        }



        public void OpenConnection()
        {


            MessageBox.Show(Globales.SQL);
            sConexion = "SERVER=" + this.server + ";" + "DATABASE=" +
                this.db + ";" + "UID=" + this.user + ";" + "PASSWORD=" + this.pass + ";";



            try
            {
                //This is my connection string i have assigned the database file address path  
                //This is my insert query in which i am taking input from the user through windows forms  
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(sConexion);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Globales.SQL, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Exito");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        //Close connection
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