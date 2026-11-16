using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Electric_Solution.Models
{
    public class UsuarioModels
    {
        //Inicializar la base de datos
        Conexion2 db = new Conexion2();

        // Declaraciones de las Propiedades (Niss, contraseña, activo)
        public string Niss { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; internal set; }

        public static string UsuarioActual { get; private set; }

        //Constructor Vacio
        public UsuarioModels() { }

        public UsuarioModels(string Niss, string Contraseña)
        {
            this.Niss = Niss;
            this.Contraseña = Contraseña;
            this.Activo = true;
        }

        //Metodo de Guardar el Usuario
        public void Guardar()
        {
            //Crear objecto con la entidad Usuario de la BD
            Cliente c = new Cliente();

            c.NumeroNiss = Niss;
            c.Contraseña = Contraseña;
            c.Activo = Activo;

            db.Cliente.Add(c);
            db.SaveChanges();
        }
        //metodo Iniciar Sesion
        public bool IniciarSesion(string Niss, string Contraseña)
        {
            var ok = db.Cliente.FirstOrDefault(c => c.NumeroNiss == Niss && c.Contraseña == Contraseña);

            if (ok == null)
                return false;

            UsuarioActual = Niss;
            return true;
        }
        // METODO CERRAR SESIÓN
        public void CerrarSesion()
        {
            UsuarioActual = null;
        }


    }
}
