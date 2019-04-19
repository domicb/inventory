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
    public partial class Form4 : Form
    {
        DBConnect nuevaConexion = new DBConnect();
        List<ProductInvoice>listaDatos = new List<ProductInvoice>();
        string sumaTotal;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            List<tipo> nuevalista = new List<tipo>();
            nuevalista = nuevaConexion.SelectTipo();
            int contador = 0;
            foreach (var item in nuevalista)
            {
                comboBoxTipo.Items.Add(nuevalista.ElementAt(contador).getipo());
                contador++;
            }

            List<Cliente> newlistCliente = new List<Cliente>();
            newlistCliente = nuevaConexion.SelectCliente();
            int contador2 = 0;
            foreach (var item in newlistCliente)
            {
                comboBoxCliente.Items.Add(newlistCliente.ElementAt(contador2).getNombre());
                contador2++;
            }

            //si no se selecciona cliente ni tipo producto no podemos dejar que guarde factura
            buttonAlbaran.Enabled = false;
            //si no hay tipo ni cliente no podemos añadir producto
            buttonProducto.Enabled = false;
            //total solo lectura
            textBoxTotal.ReadOnly = true;

        }


        public void loadGrid()
        {

            if (nuevaConexion.OpenConnection() == true)
            {
                listaDatos = nuevaConexion.SelectProducts();
                dataGridView1.Rows.Clear();
                int n = listaDatos.Count();
                int i = 0;
                double sumaParcial=0;
                double parcial;
                string partial;

                foreach (var item in listaDatos)
                {
                    //TODO
                    //UPDATE SUBPRODUCT CAMPO QUANTITY OR KG 
                    //IS NECESARY INSERT COUNT PRODUCT?
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getNombre();
                    dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getPeso();
                    dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getCantidad();
                    dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getPrecio();
                    dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getTotal();
                    partial = listaDatos.ElementAt(i).getTotal();
                    parcial = double.Parse(partial);
                    sumaParcial = sumaParcial + parcial;
                    i++;
                }

                textBoxTotalFactura.Text = sumaParcial.ToString();
                string idinvoice = nuevaConexion.getIdlast().ToString();
                nuevaConexion.UpdateInvoice(idinvoice,textBoxTotalFactura.Text);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBoxCliente.Text != "" && comboBoxTipo.Text != "" && textBoxTotal.Text != "")
            {

                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                string total = textBoxTotal.Text;
                canti = canti.Replace(".", ",");
                preci = preci.Replace(".", ",");
                string product = comboBoxTipo.Text;
                string peso = textBoxPeso.Text;

                string idproduct = nuevaConexion.idProduct(product);
                nuevaConexion.InsertProductInvoice(idproduct,preci,canti,total,peso);
                this.loadGrid();

            }
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCliente.Text != "" && comboBoxTipo.Text != "" && textBoxCantidad.Text != "" && textBoxPrecio.Text != "")
            {
                buttonProducto.Enabled = true;
            }
            else
            {
                buttonProducto.Enabled = false;
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCliente.Text != "" && comboBoxTipo.Text != "" && textBoxCantidad.Text != "" && textBoxPrecio.Text != "")
            {
                buttonProducto.Enabled = true;
            }
            else
            {
                buttonProducto.Enabled = false;
            }
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCantidad.Text != "" && textBoxPrecio.Text != "")
            {
                buttonProducto.Enabled = true;
                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                canti = canti.Replace(".",",");
                preci = preci.Replace(".", ",");
                double cantidad = double.Parse(canti);
                double precio = double.Parse(preci);
                double total = cantidad * precio;
                //total = Math.Truncate(total);
                textBoxTotal.Text = total.ToString();
            }
        }

        private void textBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text != "" && textBoxPrecio.Text != "")
            {
                buttonProducto.Enabled = true;
                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                canti = canti.Replace(".", ",");
                preci = preci.Replace(".", ",");
                double cantidad = double.Parse(canti);
                double precio = double.Parse(preci);
                double total = cantidad * precio;
                //total = Math.Truncate(total);
                textBoxTotal.Text = total.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string id_client = nuevaConexion.idClient(comboBoxCliente.Text);
            
            nuevaConexion.InsertInvoice(id_client);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
