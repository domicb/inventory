using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class tipo
    {
        string tipoProduct;
        public tipo(string tipProduct)
        {
            tipoProduct = tipProduct;
        }

        public string getipo()
        {
            return this.tipoProduct;
        }
    }
}
