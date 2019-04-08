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
            string name = textBoxProviene.Text;
            string peso = textBoxPeso.Text;
            string bultos = textBoxBultos.Text;
            string info = textBoxInfo.Text;

            nuevaConexion.OpenConnection();
            nuevaConexion.InsertEntrada(name, peso, bultos, info, DateTime.Now.ToString());
            nuevaConexion.CloseConnection();
            buttonSaveRegister.Enabled = false;
        }
    }
}
