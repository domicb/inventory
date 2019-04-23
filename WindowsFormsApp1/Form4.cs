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
            buttonFactura.Enabled = true;
            List<tipo> nuevalista = new List<tipo>();
            nuevalista = nuevaConexion.getTipoExist();
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
            //si no hay tipo ni cliente no podemos añadir producto
            buttonProducto.Enabled = false;
            //total solo lectura
            textBoxTotal.ReadOnly = true;

        }


        public void loadGrid()
        {
            if (nuevaConexion.OpenConnection() == true)
            {
                listaDatos = nuevaConexion.SelectProductsToInvoice();
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
                string peso = textBoxPeso.Text;
                canti = canti.Replace(".", ",");
                preci = preci.Replace(".", ",");
                peso = peso.Replace(".",",");
                string tipoProduct = comboBoxTipo.Text;
                string info = textBoxInfo.Text;
                
                string lote = textBoxLote.Text;

                //necesitamos llamar a exist y mandar el lote
                string idtipoProduct = nuevaConexion.idtipoProduct(tipoProduct);
                              
                Product product = new Product("Nombre", tipoProduct, peso, canti, preci, DateTime.Now, info, lote, idtipoProduct);
                lote = product.getLote();
                //comrpobamos si existe en existencias tablasubproduct 
                string idsubproduct = nuevaConexion.existe(idtipoProduct, lote);
                int cuantos = 0;
                cuantos = Int32.Parse(idsubproduct);

                if (cuantos > 0)//si existe el producto
                {
                    int operacion = 0;
                    List<Product> proAnterior = new List<Product>();
                    proAnterior = nuevaConexion.getProduct(idsubproduct);
                    DateTime ahora = DateTime.Now;
                    Product productAnterior = new Product("Nombre", "Tamaño", proAnterior.ElementAt(0).getKg(), proAnterior.ElementAt(0).getQuantity(), "Precio", ahora, "Entrada", "Lote", idtipoProduct);

                    double pes = double.Parse(productAnterior.getKg());

                    double qua = double.Parse(productAnterior.getQuantity());

                    double pes1 = double.Parse(product.getKg());

                    double qua2 = double.Parse(product.getQuantity());


                    if (pes > pes1 && qua > qua2)//si quedan existencias suficientes
                    {
                        nuevaConexion.Update(product, productAnterior, operacion, idsubproduct);
                        nuevaConexion.InsertProductInvoice(idsubproduct, preci, canti, total, peso);
                        this.loadGrid();
                    }
                    else
                    {
                        MessageBox.Show("No existen existencias suficientes para retirar esa cantidad, por favor visualiza la tabla");
                    }

                }
                else
                {
                    MessageBox.Show("No existe ningún registro de producto con ese tipo y lote");
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para ingresar el producto");
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
            if(textBoxCantidad.Text != "" && textBoxPrecio.Text != "" && textBoxPeso.Text != "")
            {
                buttonProducto.Enabled = true;
                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                string peso = textBoxPeso.Text;
                peso = peso.Replace(".", ",");
                canti = canti.Replace(".",",");
                preci = preci.Replace(".", ",");
                double pesoProduct = double.Parse(peso);
                double cantidad = double.Parse(canti);
                double precio = double.Parse(preci);
                double total = pesoProduct * precio;
                //total = Math.Truncate(total);
                textBoxTotal.Text = total.ToString();
            }
        }

        private void textBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text != "" && textBoxPrecio.Text != "" && textBoxPeso.Text != "")
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
            if(comboBoxCliente.Text != "")
            {
                string id_client = nuevaConexion.idClient(comboBoxCliente.Text);

                nuevaConexion.InsertInvoice(id_client);
                buttonFactura.Enabled = false;
            }
            else
            {
                MessageBox.Show("Necesitamos referenciar un cliente para crear la factura");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
