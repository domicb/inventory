using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUser_Enter_1(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "USUARIO")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.LightGray;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if(textBoxUser.Text == "")
            {
                textBoxUser.Text = "USUARIO";
                textBoxUser.ForeColor = Color.DimGray;
            }
        }

        private void textBoxPw_Enter(object sender, EventArgs e)
        {
            if (textBoxPw.Text == "CONTRASEÑA")
            {
                textBoxPw.Text = "";
                textBoxPw.ForeColor = Color.LightGray;
                textBoxPw.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPw_Leave(object sender, EventArgs e)
        {
            if (textBoxPw.Text == "")
            {
                textBoxPw.Text = "CONTRASEÑA";
                textBoxPw.ForeColor = Color.DimGray;
                textBoxPw.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "gambablanca" && textBoxPw.Text == "botin1") 
            {
                FormLogin nuevo = new FormLogin();
                nuevo.Show();
                
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta amigo");
            }
        }
    }
}
