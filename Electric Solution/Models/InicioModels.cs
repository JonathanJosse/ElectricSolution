using System;
using System.Linq;

namespace Electric_Solution.Models
{
    public class InicioModels
    {
        private readonly Conexion2 db = new Conexion2();

        public string Niss { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Nombre { get; set; }
        public string Notificacion { get; set; }
        public string UsuarioActual { get; private set; }

        public InicioModels()
        {
        }

        public InicioModels(
            string niss,
            decimal saldo,
            DateTime vencimiento,
            string nombre,
            string notificacion)
        {
            Niss = niss;
            Saldo = saldo;
            Vencimiento = vencimiento;
            Nombre = nombre;
            Notificacion = notificacion;
        }

        public void Guardar()
        {
            Cliente cliente = new Cliente
            {
                NumeroNiss = Niss,
                NombreCliente = Nombre
            };

            db.Cliente.Add(cliente);
            db.SaveChanges();

            Cuenta cuenta = new Cuenta
            {
                Saldo = Saldo,
                FechaVencimiento = Vencimiento,
                IdCliente = cliente.IdCliente
            };

            db.Cuenta.Add(cuenta);

            Notificacion notificacion = new Notificacion
            {
                Mensaje = Notificacion,
                FechaEnvio = DateTime.Now,
                IdCliente = cliente.IdCliente,
                Leida = false
            };

            db.Notificacion.Add(notificacion);
            db.SaveChanges();
        }

        public InicioModels ObtenerDatos(string niss)
        {
            if (string.IsNullOrWhiteSpace(niss))
            {
                return null;
            }

            Cliente cliente = db.Cliente
                .FirstOrDefault(c => c.NumeroNiss == niss && c.NombreCliente == Nombre);

            if (cliente == null)
            {
                return null;
            }

            Cuenta cuenta = db.Cuenta
                .Where(c => c.IdCliente == cliente.IdCliente)
                .OrderByDescending(c => c.IdCuenta)
                .FirstOrDefault();

            Notificacion notificacion = db.Notificacion
                .Where(n => n.IdCliente == cliente.IdCliente)
                .OrderByDescending(n => n.FechaEnvio)
                .FirstOrDefault();

            if (cuenta == null)
            {
                return null;
            }

            return new InicioModels
            {
                Niss = cliente.NumeroNiss,
                Nombre = cliente.NombreCliente,
                Saldo = cuenta.Saldo,
                Vencimiento = cuenta.FechaVencimiento,
                Notificacion = notificacion == null
                    ? string.Empty
                    : notificacion.Mensaje
            };
        }

        public bool Inicio(
            string niss,
            decimal saldo,
            DateTime vencimiento,
            string nombre,
            string notificacion)
        {
            InicioModels datos = ObtenerDatos(niss);

            if (datos == null)
            {
                return false;
            }

            bool datosValidos =
                datos.Saldo == saldo &&
                datos.Vencimiento == vencimiento &&
                string.Equals(datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(datos.Notificacion, notificacion, StringComparison.OrdinalIgnoreCase);

            if (datosValidos)
            {
                UsuarioActual = datos.Niss;
            }

            return datosValidos;
        }
    }
}
