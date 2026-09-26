using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electric_Solution
{
    public class ClienteModels
    {

        // OBJETO DE CONEXIÓN A LA BD
        Conexion1 db = new Conexion1();

        // DEFINIR LAS PROPIEDADES DE LA CLASE
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string NumeroNiss { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }

        // DEFINICIÓN DE LOS CONSTRUCTORES
        public ClienteModels(string Nombre, string Cedula, string NumeroNiss, string Correo, string Telefono, string Direccion, string Contraseña)
        {
            this.NombreCliente = Nombre;
            this.Cedula = Cedula;
            this.NumeroNiss = NumeroNiss;
            this.Correo = Correo;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Contraseña = Contraseña;
            this.Activo = true;
        }
        public ClienteModels() { }

        //Metodo de Logica
        public void Guardar()
        {
            //Objecto en la BD
            Cliente cliente = new Cliente();
            //Asignacion de valores
            cliente.NombreCliente = this.NombreCliente;
            cliente.Cedula = this.Cedula;
            cliente.NumeroNiss = this.NumeroNiss;
            cliente.Correo = this.Correo;
            cliente.telefono = this.Telefono;
            cliente.Direccion = this.Direccion;
            cliente.Contraseña = this.Contraseña;
            cliente.Activo = this.Activo;

            //Guardar Datos
            db.Cliente.Add(cliente);
            db.SaveChanges();
        }
        public List<Cliente> Listar()
        {
            return db.Cliente.Where(cliente => cliente.Activo == true).ToList();
        }
    }
}
