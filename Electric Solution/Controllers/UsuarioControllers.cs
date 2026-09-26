using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electric_Solution.Models;

namespace Electric_Solution.Controllers
{
    public class UsuarioControllers
    {
        //Iniciar Sesion 
        public bool IniciarSesion(string Niss, string Contraseña)
        {
            UsuarioModels c = new UsuarioModels();
            return c.IniciarSesion(Niss, Contraseña);
        }
        public void CerrarSesion()
        {
            UsuarioModels usuario = new UsuarioModels();
            usuario.CerrarSesion();
        }
    }
}
