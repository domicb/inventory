﻿using System;
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

        public void loadGrid()
        {
            if (nuevaConexion.getStatus() == "Open")
            {
                listaDatos = nuevaConexion.SelectProduct();
                label2.Text = listaDatos[0].ToString();
            }
            else
            {
                if (nuevaConexion.OpenConnection() == true)
                {
                    listaDatos = nuevaConexion.SelectProduct();
                    this.clearDataGrid();
                    int n = listaDatos.Count();   
                    int i = 0;

                    foreach (var item in listaDatos)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                        dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                        dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getNow();
                        dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity();
                        dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getKg();
                        dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getPrice() + " Euros";
                        i++;
                    }
                    //dataGridView1.Rows[n].Cells[0].Value = listaDatos[0].ElementAt(0);              
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

            int n = dataGridView1.Rows.Add();
            int i = 0;
            foreach (var item in listaDatos)
            {
                dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getNow();
                dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity();
                dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getKg();
                dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getPrice() + " Euros";
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
    }
}