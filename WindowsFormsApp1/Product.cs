using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Product
    {
        string name;
        string size;
        string quantity;
        string dateOut;
        string price;
        string info;
        string lote;
        string idtipo;
        string weight;
        private DateTime now;

        public Product(string name, string size, string weight, string quantity, string price, DateTime now, string info, string lote, string Tipo)
        {
            this.name = name;
            this.size = size;
            this.weight = weight;
            this.quantity = quantity;
            this.price = price;
            this.now = now;
            this.info = info;
            this.lote = lote;
            this.idtipo = Tipo;
        }

        public string getTipo()
        {
            return idtipo;
        }

        public string getLote()
        {
            if (lote == "")
            {
                lote = "Sin definir";
            }
            return lote;
        }

        public string getInfo()
        {
            return info;
        }

        public string getName()
        {
            return name;
        }

        public string getSize()
        {
            return size;
        }

        public string getKg()
        {
            return weight;
        }

        public string getPrice()
        {
            if(price == "")
            {
                price ="-1";
            }
            return price;
        }

        public string getQuantity()
        {
            return quantity;
        }

        public DateTime getNow()
        {
            return now;
        }
    }
}
