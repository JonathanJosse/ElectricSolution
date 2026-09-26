using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Electric_Solution.Models;

namespace Electric_Solution
{
    public class ClienteControllers
    {
        public void Guardar( string Nombre, string Cedula, string NumeroNiss, string Correo, string Telefono, string Direccion, string Contraseña)
        {
            ClienteModels cliente = new ClienteModels(Nombre, Cedula, NumeroNiss, Correo, Telefono, Direccion, Contraseña);
            cliente.Guardar();

        }
        public List<Cliente> Listar()
        {
            ClienteModels cliente = new ClienteModels();
            return cliente.Listar();
        }
    }
}
