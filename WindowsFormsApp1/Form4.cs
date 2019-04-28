using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        DBConnect nuevaConexion = new DBConnect();
        List<ProductInvoice>listaDatos = new List<ProductInvoice>();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        string idinvoice;

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
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
                    dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getCantidad();
                    dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getPeso();
                    dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getNombre();
                    dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getPrecio();
                    dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getTotal();
                    partial = listaDatos.ElementAt(i).getTotal();
                    parcial = double.Parse(partial);
                    sumaParcial = sumaParcial + parcial;
                    i++;
                }

                textBoxTotalFactura.Text = sumaParcial.ToString();
                idinvoice = nuevaConexion.getIdlast().ToString();
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
                
                string lote = textBoxLote.Text;

                //necesitamos llamar a exist y mandar el lote
                string idtipoProduct = nuevaConexion.idtipoProduct(tipoProduct);
                              
                Product product = new Product("Nombre", tipoProduct, peso, canti, preci, DateTime.Now, "Sin nada adicional", lote, idtipoProduct);
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


                    if (pes >= pes1 && qua >= qua2)//si quedan existencias suficientes
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
          /*  if( textBoxPrecio.Text != "" && textBoxPeso.Text != "")
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
            }*/
        }

        private void textBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            if ( textBoxPrecio.Text != "" && textBoxPeso.Text != "")
            {
                buttonProducto.Enabled = true;
                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                string peso = textBoxPeso.Text;
                peso = peso.Replace(".", ",");
                canti = canti.Replace(".", ",");
                preci = preci.Replace(".", ",");
                double pesoProduct = double.Parse(peso);
                double precio = double.Parse(preci);
                double total = pesoProduct * precio;
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

        private void textBoxPeso_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrecio.Text != "" && textBoxPeso.Text != "")
            {
                buttonProducto.Enabled = true;
                string canti = textBoxCantidad.Text;
                string preci = textBoxPrecio.Text;
                string peso = textBoxPeso.Text;
                peso = peso.Replace(".", ",");
                canti = canti.Replace(".", ",");
                preci = preci.Replace(".", ",");
                double pesoProduct = double.Parse(peso);               
                double precio = double.Parse(preci);
                double total = pesoProduct * precio;
                //total = Math.Truncate(total);
                textBoxTotal.Text = total.ToString();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            double total = double.Parse(textBoxTotalFactura.Text);
            double iva = total * 10 / 100;
            double sumaTotal = total + iva;
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top+100;
                DateTime thisDay = DateTime.Today;
                ep.Graphics.DrawString("MARISCOS CARRILLO - 697 866 650 - ALBARÁN Nº: " + idinvoice, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top - 150);
                ep.Graphics.DrawString("Avenida de la Marina,6 - 21100 Punta Umbría (Huelva) " + " - " + thisDay.ToString("d"), new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top - 120);
                ep.Graphics.DrawString("Cliente: " + comboBoxCliente.Text, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top-90);
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top);
                    left += col.Width;

                    if (col.Index < dataGridView1.ColumnCount - 1)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount - 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;
                ep.Graphics.DrawString("Total: " + total.ToString() + "€", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left+700, top + 450);
                ep.Graphics.DrawString("Iva: " + iva.ToString() + "€", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left+700, top + 475);
                ep.Graphics.DrawString("TOTAL FACTURA: "+sumaTotal.ToString()+"€", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left+700, top+500);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount - 1) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 13), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }


            };
            ppd.ShowDialog();
        }
    }
}
