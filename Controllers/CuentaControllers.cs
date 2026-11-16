using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electric_Solution.Models;

namespace Electric_Solution.Controllers
{
    public class CuentaControllers
    {
        public CuentaModels CargarDatos(string niss)
        {
            CuentaModels cuenta = new CuentaModels();

            if (!cuenta.CargarDatos(niss))
            {
                return null;
            }

            return cuenta;
        }

        public bool ActualizarCuenta(CuentaModels cuenta)
        {
            if (cuenta == null)
            {
                return false;
            }

            return cuenta.ActualizarCuenta();
        }

        public bool EliminarCuenta(CuentaModels cuenta)
        {
            if (cuenta == null)
            {
                return false;
            }

            return cuenta.EliminarCuenta();
        }
    }
}   