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
        }
    }
}
