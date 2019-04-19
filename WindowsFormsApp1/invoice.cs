using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ProductInvoice
    {
        DBConnect nuevaConexion = new DBConnect();
        string product;
        string peso;
        string cantidad;
        string total;
        string precio;
        string nombre;

        public ProductInvoice(string product, string peso, string cantidad, string total, string precio)
        {
            this.product = product;
            this.peso = peso;
            this.cantidad = cantidad;
            this.total = total;
            this.precio = precio;
        }

        public string getNombre()
        {
            nombre = nuevaConexion.getNombreProduct(product);
            return nombre;
        }

        public string getProduct()
        {
            return product;
        }
        public string getPeso()
        {
            return peso;
        }
        public string getCantidad()
        {
            return cantidad;
        }
        public string getTotal()
        {
            return total;
        }
        public string getPrecio()
        {
            return precio;
        }


    }
}
