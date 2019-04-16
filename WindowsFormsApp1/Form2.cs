using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        DBConnect nuevaConexion = new DBConnect();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonSaveRegister.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void buttonSaveRegister_Click(object sender, EventArgs e)
        {
            //string name, string email, string tlf,string dni, string direccion
            string name = textBoxNombre.Text;
            string email = textBoxEmail.Text;
            string tlf = textBoxTelefono.Text;
            string dni = textBoxDni.Text;
            string direccion = textBoxDireccion.Text;


            nuevaConexion.OpenConnection();
            nuevaConexion.InsertEntrada(name, email, tlf, dni, direccion);
            nuevaConexion.CloseConnection();
            buttonSaveRegister.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
