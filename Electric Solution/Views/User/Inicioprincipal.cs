using System;
using System.Windows.Forms;
using Electric_Solution.Controllers;
using Electric_Solution.Models;

namespace Electric_Solution.Views
{
    public partial class Inicioprincipal : UserControl
    {
        private readonly InicioControllers inicioController;

        public Inicioprincipal()
        {
            InitializeComponent();

            inicioController = new InicioControllers();
            Load += Inicioprincipal_Load;
        }

        private void Inicioprincipal_Load(object sender, EventArgs e)
        {
            string niss = UsuarioModels.UsuarioActual;

            if (string.IsNullOrWhiteSpace(niss))
            {
                MessageBox.Show("No existe un usuario autenticado.");
                return;
            }

            InicioModels datos = inicioController.ObtenerDatos(niss);

            if (datos == null)
            {
                MessageBox.Show(
                    "No se encontraron datos para el Niss: " + niss);
                return;
            }

            lbNiss.Text = "Niss: " + datos.Niss;
            lbNombre.Text = "Nombre: " + datos.Nombre;
            lbSaldo.Text = "Saldo: " + datos.Saldo.ToString("C2");
            lbVencimiento.Text =
                "Vencimiento: " +
                datos.Vencimiento.ToString("dd/MM/yyyy");
            lbNotificacion.Text =
                "Notificación: " + datos.Notificacion;
        }
    }
}
