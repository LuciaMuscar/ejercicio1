using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class Conexion
    {
        public static MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; port=3306; database=Ejercicio1; Uid=root; pwd=root; SSL Mode=none; AllowPublicKeyRetrieval=true");

        public static string consulta = "select * from alumnos";

        public static MySqlDataAdapter conector = new MySqlDataAdapter(consulta, conexion);
        public static DataSet dataSet= new DataSet("server=127.0.0.1; port=3306; database=Ejercicio1; Uid=root; pwd=root; SSL Mode=none; AllowPublicKeyRetrieval=true");

        public static bool conectarse()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

         


        public static DataSet puntoconexion()
        {
          conector.Fill(dataSet, "alumnos");

            return dataSet;
        }

    }
}
