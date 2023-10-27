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
    public partial class Login : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost; database=software_combita; Uid=root; Pwd=;");
        
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (user.Text == "Usuario")
            {
                user.Text = "";
                user.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                user.Text = "Usuario";
                user.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (Contraseña.Text == "Contraseña")
            {
                Contraseña.Text = "";
                Contraseña.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Contraseña.Text == "")
            {
                Contraseña.Text = "Contraseña";
                Contraseña.ForeColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=software_combita; Uid=root; Pwd=;");
            conexion.Open();
            string Usuario = user.Text;
            string Contra = Contraseña.Text;
            string cadena = "select user, password from user where user= @usuario and password= @contraseña";
            MySqlCommand comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@usuario", Usuario);
            comando.Parameters.AddWithValue("@contraseña", Contra);
            MySqlDataReader registro = comando.ExecuteReader();


            if (registro.Read())
            {
                Productos x = new Productos();
                this.Hide();
                x.Show();
            }
            else

                MessageBox.Show("Usuario y/o contraseña incorrecto");
            conexion.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_mostrar_Click(object sender, EventArgs e)
        {
            if (Contraseña.UseSystemPasswordChar)
            {
                Contraseña.UseSystemPasswordChar = false;
            }
            else
            {
                Contraseña.UseSystemPasswordChar = true;
            }

            button_ocultar.Visible = true;
            button_mostrar.Visible = false;
        }

        private void button_ocultar_Click(object sender, EventArgs e)
        {
            if (Contraseña.UseSystemPasswordChar)
            {
                Contraseña.UseSystemPasswordChar = false;
            }
            else
            {
                Contraseña.UseSystemPasswordChar = true;
            }
            button_ocultar.Visible = false;
            button_mostrar.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has salido del programa");
            this.Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortDateString();
            label3.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}