using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SimpleInvoice
    {
        DBConnect nuevaConexion = new DBConnect();
        string fecha;
        string total;
        string cliente;
        string numalb;

        public SimpleInvoice(string numalb,string fecha, string total, string cliente)
        {
            this.numalb = numalb;
            this.fecha = fecha;
            this.total = total;
            this.cliente = cliente;
        }

        public string getAlb()
        {
            return this.numalb;
        }

        public string getFecha()
        {
            return this.fecha;
        }
        public string getTotal()
        {
            return this.total;
        }
        public string getClient()
        {
            return this.cliente;
        }

    }
}
