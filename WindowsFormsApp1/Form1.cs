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
    public partial class FormLogin : Form
    {
        string passwordDB = "GambaBlanca80";
        bool conexion = false;
        DBConnect nuevaConexion = new DBConnect();
        List<Product> listaDatos = new List<Product>();


        public FormLogin()
        {
            InitializeComponent();
            this.loadGrid();          
        }

        public void Refrescar()
        {
           for(int i=0; i < 29; i++)
            {
                nuevaConexion.InsertCount(i);
            }
        }

        public void loadGrid()
        {
            if (nuevaConexion.getStatus() == "Open")
            {
                listaDatos = nuevaConexion.SelectSubProduct();
                label2.Text = listaDatos[0].ToString();
            }
            else
            {
                if (nuevaConexion.OpenConnection() == true)
                {
                    listaDatos = nuevaConexion.SelectSubProduct();
                    this.clearDataGrid();
                    int n = listaDatos.Count();   
                    int i = 0;

                    foreach (var item in listaDatos)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                        dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                        dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getKg();
                        dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity()+ " Cajas";
                        dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getLote();
                        dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getInfo();

                        i++;
                    }        
                }
            }
        }

        public void conect()
        {
            conexion = nuevaConexion.OpenConnection();
            if (conexion)
            {
                label2.Text = "Conectado";
            }
            else
            {
                label2.Text = "Hubo un problema con la conexión a la base de datos, domi1213@hotmail.com";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {     
            label2.Text = nuevaConexion.getStatus(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 newProduct = new Form3();
            newProduct.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //obtiene el valor de la celda seleccionada
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            listaDatos = nuevaConexion.SelectSubProduct(label2.Text);

            int i = 0;
            foreach (var item in listaDatos)
            {
                dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getKg();
                dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity();
                dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getLote();
                dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getInfo();
                i++;
            }
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            conexion = nuevaConexion.OpenConnection();
            if (conexion)
            {
                label2.Text = "Conectado";
            }
            else
            {
                label2.Text = "Hubo un problema con la conexión a la base de datos, domi1213@hotmail.com";
            }
        }

        public void clearDataGrid()
        {
            dataGridView1.Rows.Clear();
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clearDataGrid();
            this.loadGrid();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            listaDatos = nuevaConexion.SelectSubProduct(label2.Text);
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            listaDatos = nuevaConexion.SelectSubProduct(label2.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Refrescar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 newPro = new Form2();
            newPro.Show();
        }

        private void buttonSalida_Click(object sender, EventArgs e)
        {
            Form4 newSalida = new Form4();
            newSalida.Show();
        }
    }
}
