using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormularioMDI
{
    class clsCliente
    {
       
        public int Telefono { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public clsCliente( int telefono, int documento, string Nombre, string Apellido, string email)
        {
       
            this.Telefono = telefono;
            this.Documento = documento;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = email;
        }

        public clsCliente()
        {

        }


    }

}

