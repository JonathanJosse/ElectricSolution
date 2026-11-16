using Electric_Solution.Models;

namespace Electric_Solution.Controllers
{
    public class InicioControllers
    {
        public InicioModels ObtenerDatos(string niss)
        {
            InicioModels inicio = new InicioModels();

            return inicio.ObtenerDatos(niss);
        }
    }
}
