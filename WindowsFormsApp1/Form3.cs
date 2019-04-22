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
    public partial class Form3 : Form
    {
        DBConnect nuevaConexion = new DBConnect();
        public Form3()
        {
            InitializeComponent();    
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxTipo.Text != "")
            {               
                string name = textDescription.Text;
                string size = comboBoxTipo.SelectedItem.ToString();
                string quantity = textCantidad.Text;
                string weight = textPeso.Text;
                //int peso = int.Parse(weight);
                //int cantidad = int.Parse(quantity);
                //int media = peso / cantidad;
                string price = textBoxPrecio.Text;
                string info = textBoxInfo.Text;             
                string lote = textBoxLote.Text;

                string tipo = comboBoxTipo.SelectedItem.ToString();
                //solicitamos la id del tipo
                tipo = nuevaConexion.idtipoProduct(tipo);
                //necesitamos saber si existe algún registro de producto con ese tipo, sería update no insert               
                
                int idTipo = int.Parse(tipo);
                Product product = new Product(name, size, weight, quantity, price, DateTime.Now, info, lote, tipo);
                lote = product.getLote();//lo traemos de nuevo para parsear dato vacio
                string idsubproduct = nuevaConexion.existe(tipo, lote);                
                int tieneElementos = Int32.Parse(idsubproduct);

                if (tieneElementos > 0)
                {//nos creamos una lista para recoger los valores anteriores
                    List<Product> proAnterior = new List<Product>();
                    proAnterior = nuevaConexion.getProduct(idsubproduct);

                    //indicamos que es una actualización por suma insert product
                    int tipOperacion = 1;

                    DateTime ahora = DateTime.Now;
                    //recogemos los valores anteriores para sumarlos o restarlos
                    Product productAnterior = new Product("Nombre","Tamaño",proAnterior.ElementAt(0).getKg(),proAnterior.ElementAt(0).getQuantity(),"Precio",ahora,"Entrada","Lote",tipo);
                    nuevaConexion.Update(product,productAnterior,tipOperacion,idsubproduct);
                    MessageBox.Show("Existe un registro para este producto: "+idsubproduct+" por tanto hemos actualizado su peso y cantidad");
                }
                else
                {
                    nuevaConexion.OpenConnection();
                    nuevaConexion.Insert(product);
                    MessageBox.Show("El producto con id: " + idsubproduct + " se ha registrado correctamente en la Base de datos");
                    nuevaConexion.CloseConnection();
                }              

            }
            else
            {
                labelError.Text = "El campo Tipo Producto está vacio";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string quantity = textCantidad.Text;
            string weight = textPeso.Text;
            weight = weight.Replace(".", ",");
            quantity = quantity.Replace(".", ",");
            if (textCantidad.Text != "" && textPeso.Text !="")
            {
                LabelPesoMedio.BackColor = Color.Green;
                double peso = double.Parse(weight);
                double cantidad = double.Parse(quantity);
                double media = peso / cantidad;
                LabelPesoMedio.Text = media.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void buttonModify_Click(object sender, EventArgs e)
        {

            /*//string padre = comboBoxPadre.Text;
            string name = textDescription.Text;
            //string tipo = comboBoxTipo.Text;
            string size = comboBoxTipo.Text;
            string quantity = textCantidad.Text;
            string weight = textPeso.Text;
            string price = "No calculado";
            string info = textBoxInfo.Text;
            string lote = textBoxLote.Text;
            string tipo = comboBoxTipo.Text;

            Product product = new Product(name, size, weight, quantity, price, DateTime.Now, info, lote,tipo);
            nuevaConexion.OpenConnection();
            nuevaConexion.Update(product);
            MessageBox.Show("El producto: " + name + " se ha actualizado correctamente en la Base de datos");
            nuevaConexion.CloseConnection();*/
            
        }

        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<tipo> nuevalista = new List<tipo>();
            nuevalista = nuevaConexion.SelectTipo();
            int contador = 0;
            foreach (var item in nuevalista)
            {
                comboBoxTipo.Items.Add(nuevalista.ElementAt(contador).getipo());
                contador++;
            }
        }

        private void textPeso_TextChanged(object sender, EventArgs e)
        {
            string quantity = textCantidad.Text;
            string weight = textPeso.Text;
            weight = weight.Replace(".",",");
            quantity = quantity.Replace(".", ",");
            if (textCantidad.Text != "" && textPeso.Text != "")
            {
                LabelPesoMedio.BackColor = Color.Green;
                double peso = double.Parse(weight);
                double cantidad = double.Parse(quantity);
                double media = peso / cantidad;
                media = Math.Truncate(media);
                LabelPesoMedio.Text = media.ToString();
            }
        }
    }
}
