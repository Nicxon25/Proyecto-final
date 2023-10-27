using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class Clientes : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost; database=proyecto; Uid=root; Pwd=;");
        public Clientes()
        { 
       
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "¿Deseas cerrar sesión?";
            string title = "Cerrar la ventana";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Productos x = new Productos();
            this.Hide();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Cedula = cedula.Text;
            string Nombre = nombre.Text;
            string Telefono = telefono.Text;
            string Correo = correo.Text;

            if (cedula.Text == "Cedula" || nombre.Text == "Nombre" || telefono.Text == "Telefono" || correo.Text == "Correo")
            {
                MessageBox.Show("Por favor ingresar datos");
            }
            else
            {
                conexion.Open();
                string cadena = "insert into cliente (cedula,nombre,telefono,correo) values ('" + Cedula + "','" + Nombre + "','" + Telefono + "','" + Correo + "')";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Los datos se guardaron éxitosamente");

                cedula.Text = "";
                nombre.Text = "";
                telefono.Text = "";
                correo.Text = "";

                string cadena2 = "select * from cliente";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tabla_mostrar.DataSource = dt;


                conexion.Close();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string id = label_id.Text;
            string Cedula = cedula.Text;
            string Nombre = nombre.Text;
            string Telefono = telefono.Text;
            string Correo = correo.Text;
            string cadena = " UPDATE cliente SET cedula=" + "'" + Cedula + "',nombre='" + Nombre + "'," + "telefono='" + Telefono + "',correo='" + Correo + "'" + " WHERE idcliente = '" + id + "'";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Los datos se han modificado éxitosamente");
                label_id.Text = "id";
                cedula.Text = "";
                nombre.Text = "";
                telefono.Text = "";
                correo.Text = "";
                string cadena2 = "SELECT * FROM cliente";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tabla_mostrar.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Datos no identificados");
            }
            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factura x = new Factura();
            this.Hide();
            x.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            string cadena2 = "select * from cliente";

            MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            tabla_mostrar.DataSource = dt;

            conexion.Close();
        }

        private void tabla_mostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label_id.Text = tabla_mostrar.SelectedCells[0].Value.ToString();
            cedula.Text = tabla_mostrar.SelectedCells[1].Value.ToString();
            nombre.Text = tabla_mostrar.SelectedCells[2].Value.ToString();
            telefono.Text = tabla_mostrar.SelectedCells[3].Value.ToString();
            correo.Text = tabla_mostrar.SelectedCells[4].Value.ToString();
        }

        private void tabla_mostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = label_id.Text;
            string cadena = "DELETE FROM cliente WHERE idcliente=" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("El cliente se ha eliminado éxitosamente");

                label_id.Text = "id";
                cedula.Text = "";
                nombre.Text = "";
                telefono.Text = "";
                correo.Text = "";

                string cadena2 = "SELECT * FROM cliente";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tabla_mostrar.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Cliente no identificado");
            }
            conexion.Close();
        }
    }
}
