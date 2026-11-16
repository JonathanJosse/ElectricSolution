using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electric_Solution.Models
{
    public class CuentaModels
    {
        public string Niss { get; internal set; }
        public string Nombre { get; internal set; }
        public string Cedula { get; internal set; }
        public string Telefono { get; internal set; }
        public string Correo { get; internal set; }
        public string Direccion { get; internal set; }
        public object Saldo { get; internal set; }
        public DateTime FechaVencimiento { get; internal set; }
    }
}
