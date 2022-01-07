using MySql.Data.MySqlClient;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
   public class Alumnos : Personas
    {
        int cant_materias;
        string deben;

        public Alumnos ()
        {
        }
        public Alumnos(int ci,string nombre,int año,int cant_materias,string deben) :base(ci,nombre,año)
        {
            this.cant_materias = cant_materias;
            this.deben = deben;
        }

        public Alumnos(int ci)
        {
            this.Ci = ci;
        }

        public Alumnos(int ci, string nombre)
        {
            this.Ci = Ci;
            this.Nombre = Nombre;
        }
       

        public int Cant_materias
        {
            get { return cant_materias; }
            set { cant_materias = value; }
        }
        public string Deben
        {
            get { return deben; }
            set { deben = value; }
        }

        public void agregarAlumnos()
        {
            MySqlCommand comando = new MySqlCommand("Insert into Personas values(@ci, @n, @a)", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.Ci);
            comando.Parameters.AddWithValue("@n", this.Nombre);
            comando.Parameters.AddWithValue("@a", this.Año);
            comando.ExecuteNonQuery();
            MySqlCommand comando2 = new MySqlCommand("Insert into Alumnos values(@ci2, @c, @d)", Conexion.conexion);
            comando2.Parameters.AddWithValue("@ci2", this.Ci);
            comando2.Parameters.AddWithValue("@c", this.Cant_materias);
            comando2.Parameters.AddWithValue("@d", this.deben);
            comando2.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }

        public void eliminarAlumnos()
        {
            MySqlCommand comando = new MySqlCommand("Delete from Alumnos where ci=@ci", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.Ci);
            comando.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }

        public void modificarAlumnos()
        {
            MySqlCommand comando = new MySqlCommand("Update Personas set nombre=@n, año=@a where ci=@ci", Conexion.conexion);
            comando.Parameters.AddWithValue("@ci", this.Ci);
            comando.Parameters.AddWithValue("@n", this.Nombre);
            comando.Parameters.AddWithValue("@a", this.Año);
            comando.ExecuteNonQuery();
            MySqlCommand comando2 = new MySqlCommand("Update Alumnos set cant_materias=@c, deben=@d where ci=@ci2", Conexion.conexion);
            comando2.Parameters.AddWithValue("@ci2", this.Ci);
            comando2.Parameters.AddWithValue("@c", this.Cant_materias);
            comando2.Parameters.AddWithValue("@d", this.deben);
            comando2.ExecuteNonQuery();
            MessageBox.Show("Hecho");
        }
    }
}