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
        List<Cliente> listaDatos = new List<Cliente>();

        public Form2()
        {
            InitializeComponent();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            buttonSaveRegister.Enabled = true;
            this.loadGrid();
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

        public void loadGrid()
        {
            if (nuevaConexion.OpenConnection() == true)
            {
                listaDatos = nuevaConexion.SelectCliente();
                dataGridView1.Rows.Clear();
                int n = listaDatos.Count();
                int i = 0;
                double sumaParcial = 0;
                double parcial;
                string partial;

                foreach (var item in listaDatos)
                {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getNombre();
                    dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).geTlf();
                    dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getEmail();
                    dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getDni();
                    dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getDirec();
                    i++;
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
