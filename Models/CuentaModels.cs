using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electric_Solution.Models
{
    public class CuentaModels
    {
        private readonly Conexion2 db = new Conexion2();

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }

        public string Niss { get; set; }
        public decimal Saldo { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public bool CargarDatos(string niss)
        {
            if (string.IsNullOrWhiteSpace(niss))
            {
                return false;
            }

            var datos = (
                from cliente in db.Cliente
                join cuenta in db.Cuenta
                    on cliente.IdCliente equals cuenta.IdCliente
                where cliente.NumeroNiss == niss
                orderby cuenta.IdCuenta descending
                select new
                {
                    cuenta.IdCuenta,
                    cliente.IdCliente,
                    cliente.NumeroNiss,
                    cuenta.Saldo,
                    cliente.NombreCliente,
                    cliente.Cedula,
                    cliente.telefono,
                    cliente.Correo,
                    cliente.Direccion,
                    cuenta.FechaVencimiento
                })
                .FirstOrDefault();

            if (datos == null)
            {
                return false;
            }

            IdCuenta = datos.IdCuenta;
            IdCliente = datos.IdCliente;
            Niss = datos.NumeroNiss;
            Saldo = datos.Saldo;
            Nombre = datos.NombreCliente;
            Cedula = datos.Cedula;
            Telefono = datos.telefono;
            Correo = datos.Correo;
            Direccion = datos.Direccion;
            FechaVencimiento = datos.FechaVencimiento;

            return true;
        }

        public bool ActualizarCuenta()
        {
            if (string.IsNullOrWhiteSpace(Niss))
            {
                return false;
            }

            Cliente cliente = db.Cliente
                .FirstOrDefault(c => c.NumeroNiss == Niss);

            if (cliente == null)
            {
                return false;
            }

            Cuenta cuenta = db.Cuenta
                .FirstOrDefault(c =>
                    c.IdCuenta == IdCuenta &&
                    c.IdCliente == cliente.IdCliente);

            if (cuenta == null)
            {
                return false;
            }

            cliente.NombreCliente = Nombre;
            cliente.Cedula = Cedula;
            cliente.telefono = Telefono;
            cliente.Correo = Correo;
            cliente.Direccion = Direccion;

            cuenta.Saldo = Saldo;
            cuenta.FechaVencimiento = FechaVencimiento;

            db.SaveChanges();

            return true;
        }

        public bool EliminarCuenta()
        {
            Cuenta cuenta = db.Cuenta
                .FirstOrDefault(c =>
                    c.IdCuenta == IdCuenta &&
                    c.IdCliente == IdCliente);

            if (cuenta == null)
            {
                return false;
            }

            db.Cuenta.Remove(cuenta);
            db.SaveChanges();

            return true;
        }
    }
}