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
    public partial class Form5 : Form
    {
        DBConnect nuevaConexion = new DBConnect();
        List<SimpleInvoice> listaDatos = new List<SimpleInvoice>();
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Form5_Load(object sender, EventArgs e)
        {
            this.loadGrid();
        }

        public void loadGrid()
        {
            if (nuevaConexion.OpenConnection() == true)
            {
                listaDatos = nuevaConexion.SelectInvoices();
                dataGridView1.Rows.Clear();
                int n = listaDatos.Count();
                int i = 0;
                double sumaParcial = 0;
                double parcial;
                string partial;

                foreach (var item in listaDatos)
                {
                    string nombre = nuevaConexion.nameClient(listaDatos.ElementAt(i).getClient());
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getAlb();
                    dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getFecha();
                    dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getTotal();
                    dataGridView1.Rows[i].Cells[3].Value = nombre;
                    i++;
                }

            }
        }

        private void buttonNewSalida_Click(object sender, EventArgs e)
        {
            Form4 newSalida = new Form4();
            newSalida.Show();
        }
    }
}
