using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electric_Solution.Controllers;
using Electric_Solution.Models;

namespace Electric_Solution.Views.User
{
    public partial class Uc_Cuenta : UserControl
    {
        private object cuentaActual;
        // Cambiar el tipo de dtpVencimiento a DateTimePicker para acceder a la propiedad Value
        private DateTimePicker dtpVencimiento;
        private CuentaControllers cuentaControllers;      

        public Uc_Cuenta()
        {
            InitializeComponent();
            cuentaControllers = new CuentaControllers   ();
            // dtpVencimiento = this.Controls.Find("dtpVencimiento", true).FirstOrDefault() as DateTimePicker;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos(txtNiss.Text);
        }

        // Mover CargarDatos fuera del método btnCargar_Click y corregir la indentación
        public void CargarDatos(string niss)
        {
            if (string.IsNullOrWhiteSpace(niss))
            {
                MessageBox.Show("Ingrese un NISS.");
                return;
            }

            CuentaModels cuenta = cuentaControllers.CargarDatos(niss);

            if (cuenta == null)
            {
                cuentaActual = null;

                MessageBox.Show(
                    "No se encontraron datos para el NISS indicado.");

                return;
            }

            cuentaActual = cuenta;

            txtNiss.Text = cuenta.Niss;
            txtNombre.Text = cuenta.Nombre;
            txtCedula.Text = cuenta.Cedula;
            txtTelefono.Text = cuenta.Telefono;
            txtCorreo.Text = cuenta.Correo;
            txtDireccion.Text = cuenta.Direccion;
            txtSaldo.Text = Convert.ToString(
                cuenta.Saldo,
                CultureInfo.CurrentCulture);
            // Ahora dtpVencimiento es un DateTimePicker, por lo que se puede asignar el valor correctamente
            dtpVencimiento.Value = cuenta.FechaVencimiento;
        }
    }       
}
