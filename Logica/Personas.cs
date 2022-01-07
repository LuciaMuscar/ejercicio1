using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Persistencia;
using System.Windows.Forms;

namespace Logica
{
    public class Personas
    {
        int ci;
        string nombre;
        int año;

        public Personas()
        {
        }

        public Personas(int ci)
        {
            this.ci = ci;
        }

        public Personas(int ci, string nombre, int año)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.año = año;
        }

        public int Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        public void agregarPersonas()
        {
            MySqlCommand comando = new MySqlCommand("Insert into Personas values(@ci, @n, @s)", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.ci);
            comando.Parameters.AddWithValue("@n", this.nombre);
            comando.Parameters.AddWithValue("@s", this.año);
            comando.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }

        public void eliminarPersonas()
        {
            MySqlCommand comando = new MySqlCommand("Delete from Personas where ci=@ci", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.ci);
            comando.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }

        public void modificarPersonas()
        {
            MySqlCommand comando = new MySqlCommand("Update Personas set nombre=@n, año=@s where ci=@ci", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.ci);
            comando.Parameters.AddWithValue("@n", this.nombre);
            comando.Parameters.AddWithValue("@s", this.año);
            comando.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }
    }
}
