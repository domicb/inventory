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
            comboBoxTipo.SelectedIndex = 0;
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.comboBoxPadre, "Nombre del padre");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTipo.Text == "Producto Hijo")
            {
                comboBoxPadre.Visible = true;
                List<Product> nuevalista = new List<Product>();
                nuevalista = nuevaConexion.SelectProduct();
                int contador = 0;
                foreach (var item in nuevalista)
                {                  
                    comboBoxPadre.Items.Add(nuevalista.ElementAt(contador).getName());
                    contador++;
                }

                //nuevaConexion.loadPadre();
            }
            else
            {
                comboBoxPadre.Visible = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textDescription.Text != "")
            {
                string padre = comboBoxTipo.Text;
                string name = textDescription.Text;
                string tipo = comboBoxTipo.Text;
                string size = textSize.Text;
                string quantity = textQuantity.Text;
                string weight = textKg.Text;
                string price = textPrice.Text;
                string info = textBoxInfo.Text;
               
                Product product = new Product(name, size, weight, quantity, price, DateTime.Now, info);

                nuevaConexion.OpenConnection();
                nuevaConexion.Insert(product, padre);
                MessageBox.Show("El producto: " + name + " se ha guardado en la Base de datos");
                nuevaConexion.CloseConnection();
            }
            else
            {
                labelError.Text = "El campo nombre está vacio";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void buttonModify_Click(object sender, EventArgs e)
        {

            string padre = comboBoxPadre.Text;
            string name = textDescription.Text;
            string tipo = comboBoxTipo.Text;
            string size = textSize.Text;
            string quantity = textQuantity.Text;
            string weight = textKg.Text;
            string price = textPrice.Text;
            string info = textBoxInfo.Text;

            Product product = new Product(name, size, weight, quantity, price, DateTime.Now, info);
            nuevaConexion.OpenConnection();
            nuevaConexion.Update(product, padre);
            MessageBox.Show("El producto: " + name + " se ha actualizado correctamente en la Base de datos");
            nuevaConexion.CloseConnection();
        }

        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
