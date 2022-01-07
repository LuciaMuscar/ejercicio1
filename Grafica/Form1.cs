using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using MySql.Data.MySqlClient;
using Persistencia;

namespace Grafica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.conectarse();
         
            
            label4.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
        }

        private void butAg_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    Personas p1 = new Personas(Convert.ToInt32(textBox1.Text), textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text));
                    p1.agregarPersonas();
                }
                else
                {
                    Alumnos a1 = new Logica.Alumnos(Convert.ToInt32(textBox1.Text), textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text.Trim());
                    a1.agregarAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese bien los datos "+ex.Message);
            }
        }

        private void butBor_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    Personas e1 = new Personas(Convert.ToInt32(textBox1.Text));
                    e1.eliminarPersonas();
                }
                else
                {
                    Alumnos j1 = new Logica.Alumnos(Convert.ToInt32(textBox1.Text));
                    j1.eliminarAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese bien los datos " + ex.Message);
            }
        }

        private void butMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    Personas e1 = new Personas(Convert.ToInt32(textBox1.Text), textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text));
                    e1.modificarPersonas();
                }
                else
                {
                    Alumnos j1 = new Logica.Alumnos(Convert.ToInt32(textBox1.Text), textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text.Trim());
                    j1.modificarAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese bien los datos " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label4.Visible = false;
                label5.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
            }
        }

        private void butList_Click(object sender, EventArgs e)
        {
            //   new SqlCommand(“sql / SP”, objSqlConnection);
            //    Conexion c = new Conexion();
            //  Conexion.puntoconexion;
            try
            {
                dataSet1 = Conexion.puntoconexion();
                //dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = dataSet1.Tables;
                // dataGridView1.DataMember = "alumnos";
                // dataGridView1.DataMember.= "alumnos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error "+ex.Message);
            }
        }

        
    }
}
