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
        string dateIn;
        string dateOut;
        string kg;
        string price;
        private string weight;
        private DateTime now;

        public Product(string name, string size, string kg, string quantity, string price, string dateIn)
        {
            this.name = name;
            this.size = size;
            this.kg = kg;
            this.quantity = quantity;
            this.price = price;
            this.dateIn = dateIn;
        }

        public Product(string name, string size, string weight, string quantity, string price, DateTime now)
        {
            this.name = name;
            this.size = size;
            this.weight = weight;
            this.quantity = quantity;
            this.price = price;
            this.now = now;
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
            return kg;
        }

        public string getPrice()
        {
            return price;
        }

        public string getQuantity()
        {
            return quantity;
        }

        public string getDateIn()
        {
            return dateIn;
        }
    }
}
