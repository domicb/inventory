using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cliente
    {
        string nombre;
        string email;
        string dni;
        string tlf;
        string direccion;

        public Cliente(string nombre, string email, string dni, string tlf, string direccion)
        {
            this.nombre = nombre;
            this.email = email;
            this.dni = dni;
            this.tlf = tlf;
            this.direccion = direccion;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getEmail()
        {
            return email;
        }

        public string getDni()
        {
            return dni;
        }

        public string geTlf()
        {
            return tlf;
        }

        public string getDirec()
        {
            return direccion;
        }
    }
}
