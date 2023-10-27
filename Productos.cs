using MySql.Data.MySqlClient;
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

namespace Proyecto_final
{
    public partial class Productos : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost; database=proyecto; Uid=root; Pwd=;");

        public Productos()
        {
            InitializeComponent();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "¿Deseas cerrar sesión?";
            string title = "Cerrar la ventana";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Login x = new Login();
                this.Hide();
                x.Show();
            }
            else
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes x = new Clientes();
            this.Hide();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factura x = new Factura();
            this.Hide();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conexion.Open();    
            string id = label_id.Text;
            string cadena = "DELETE FROM producto WHERE idproducto=" + id;
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("El producto se ha borrado éxitosamente");

                label_id.Text = "id";
                codigo.Text = "";
                producto.Text = "";
                existencias.Text = "";
                precio.Text = "";

                string cadena2 = "SELECT * FROM producto";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tabla_mostrar.DataSource = dt;
                
            }
            else
            {
                MessageBox.Show("Producto no identificado");
            }
            conexion.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string id = label_id.Text;
            string Codigo = codigo.Text;
            string Producto = producto.Text;
            string Existencias = existencias.Text;
            string Precio = precio.Text;
            string cadena = " UPDATE producto SET Codigo=" + "'" + Codigo + "',Producto='" + Producto + "'," + "Existencias='" + Existencias + "',Precio='" + Precio + "'" + " WHERE idproducto= '" + id + "'";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Los datos se han modificado éxitosamente");
                label_id.Text = "id";
                codigo.Text = "";
                producto.Text = "";
                existencias.Text = "";
                precio.Text = "";
                string cadena2 = "SELECT * FROM producto";

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

        private void button6_Click(object sender, EventArgs e)
        {
            string Codigo = codigo.Text;
            string Producto = producto.Text;
            string Existencias = existencias.Text;
            string Precio = precio.Text;

            if (codigo.Text == "Codigo" || producto.Text == "Producto" || existencias.Text == "Existencias" || precio.Text == "Precio")
            {
                MessageBox.Show("Por favor ingresar datos");
            }
            else
            {
                conexion.Open();
                string cadena = "insert into producto(codigo,producto,existencias,precio) values ('" + Codigo + "','" + Producto + "','" + Existencias + "','" + Precio + "')";
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Los datos se guardaron éxitosamente");

                codigo.Text = "";
                producto.Text = "";
                existencias.Text = "";
                precio.Text = "";

                string cadena2 = "select * from Producto";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tabla_mostrar.DataSource = dt;
               

                conexion.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            string cadena2 = "select * from Producto";

            MySqlDataAdapter adaptador = new MySqlDataAdapter(cadena2, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            tabla_mostrar.DataSource = dt;

            conexion.Close();   
        }

        private void tabla_mostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label_id.Text = tabla_mostrar.SelectedCells[0].Value.ToString();
            codigo.Text = tabla_mostrar.SelectedCells[1].Value.ToString();
            producto.Text = tabla_mostrar.SelectedCells[2].Value.ToString();
            existencias.Text = tabla_mostrar.SelectedCells[3].Value.ToString();
            precio.Text = tabla_mostrar.SelectedCells[4].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void tabla_mostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
  
        {
            conexion.Open();    
            string searchTerm = textBox_buscar.Text;
            string cadena = "SELECT producto AS Producto,Codigo,Existencias,Precio FROM producto WHERE producto LIKE @parametro";
            using (MySqlCommand command = new MySqlCommand(cadena, conexion))
            {
                command.Parameters.AddWithValue("@parametro", "%" + searchTerm + "%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    tabla_mostrar.DataSource = dataTable;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
