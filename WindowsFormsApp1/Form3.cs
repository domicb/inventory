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
            if (textDescription.Text != "")
            {               
                string name = textDescription.Text;
                string size = textSize.Text;
                string quantity = textCantidad.Text;
                string weight = textPeso.Text;
                //int peso = int.Parse(weight);
                //int cantidad = int.Parse(quantity);
                //int media = peso / cantidad;
                string price = textBoxPrecio.Text;
                string info = textBoxInfo.Text;             
                string lote = textBoxLote.Text;
                string tipo = comboBoxTipo.SelectedItem.ToString();
                tipo = nuevaConexion.idTipo(tipo);
                int idTipo = int.Parse(tipo);
                Product product = new Product(name, size, weight, quantity, price, DateTime.Now, info, lote, tipo);

                nuevaConexion.OpenConnection();
                nuevaConexion.Insert(product,idTipo);
                MessageBox.Show("El producto: " + name + " se ha registrado correctamente en la Base de datos");
                nuevaConexion.CloseConnection();
            }
            else
            {
                labelError.Text = "El campo nombre está vacio";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string quantity = textCantidad.Text;
            string weight = textPeso.Text;
            if(textCantidad.Text != "" && textPeso.Text !="")
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

            //string padre = comboBoxPadre.Text;
            string name = textDescription.Text;
            //string tipo = comboBoxTipo.Text;
            string size = textSize.Text;
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
            nuevaConexion.CloseConnection();
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
