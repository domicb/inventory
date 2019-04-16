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

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBoxCliente.Text != "" && comboBoxTipo.Text != "")
            {
                MessageBox.Show("Funca macho");
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
                double cantidad = double.Parse(textBoxCantidad.Text);
                double precio = double.Parse(textBoxPrecio.Text);
                double total = cantidad * precio;
                textBoxTotal.Text = total.ToString();
            }
        }

        private void textBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text != "" && textBoxPrecio.Text != "")
            {
                double cantidad = double.Parse(textBoxCantidad.Text);
                double precio = double.Parse(textBoxPrecio.Text);
                double total = cantidad * precio;
                textBoxTotal.Text = total.ToString();
            }
        }
    }
}
