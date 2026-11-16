using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Electric_Solution.Controllers;
using Electric_Solution.Models;

namespace Electric_Solution.Views.User
{
    public class UCCuenta : UserControl
    {
        private readonly CuentaControllers cuentaController =
            new CuentaControllers();

        private CuentaModels cuentaActual;

        private TextBox txtNiss;
        private TextBox txtNombre;
        private TextBox txtCedula;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtSaldo;
        private DateTimePicker dtpVencimiento;

        private Button btnCargar;
        private Button btnActualizar;
        private Button btnEliminar;

        public UCCuenta()
        {
            InicializarControles();

            Load += UCCuenta_Load;
        }

        private void UCCuenta_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsuarioModels.UsuarioActual))
            {
                txtNiss.Text = UsuarioModels.UsuarioActual;
                CargarDatos(txtNiss.Text);
            }
        }

        private void InicializarControles()
        {
            Text = "Cuenta";
            BackColor = Color.White;
            AutoScroll = true;

            TableLayoutPanel tabla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 10,
                Padding = new Padding(20),
                AutoSize = true
            };

            tabla.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 150));
            tabla.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            txtNiss = CrearTextBox();
            txtNombre = CrearTextBox();
            txtCedula = CrearTextBox();
            txtTelefono = CrearTextBox();
            txtCorreo = CrearTextBox();
            txtDireccion = CrearTextBox();
            txtSaldo = CrearTextBox();

            dtpVencimiento = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Short
            };

            btnCargar = new Button
            {
                Text = "Cargar datos",
                AutoSize = true
            };

            btnActualizar = new Button
            {
                Text = "Actualizar cuenta",
                AutoSize = true
            };

            btnEliminar = new Button
            {
                Text = "Eliminar cuenta",
                AutoSize = true
            };

            btnCargar.Click += BtnCargar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            AgregarFila(tabla, "NISS:", txtNiss);
            AgregarFila(tabla, "Nombre:", txtNombre);
            AgregarFila(tabla, "Cédula:", txtCedula);
            AgregarFila(tabla, "Teléfono:", txtTelefono);
            AgregarFila(tabla, "Correo:", txtCorreo);
            AgregarFila(tabla, "Dirección:", txtDireccion);
            AgregarFila(tabla, "Saldo:", txtSaldo);
            AgregarFila(tabla, "Vencimiento:", dtpVencimiento);

            FlowLayoutPanel botones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            botones.Controls.Add(btnCargar);
            botones.Controls.Add(btnActualizar);
            botones.Controls.Add(btnEliminar);

            tabla.Controls.Add(new Label(), 0, 8);
            tabla.Controls.Add(botones, 1, 8);

            Controls.Add(tabla);
        }

        private TextBox CrearTextBox()
        {
            return new TextBox
            {
                Dock = DockStyle.Fill
            };
        }

        private void AgregarFila(
            TableLayoutPanel tabla,
            string etiqueta,
            Control control)
        {
            int fila = tabla.Controls.Count / 2;

            tabla.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            tabla.Controls.Add(
                new Label
                {
                    Text = etiqueta,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                },
                0,
                fila);

            tabla.Controls.Add(control, 1, fila);
        }

        public void CargarDatos(string niss)
        {
            if (string.IsNullOrWhiteSpace(niss))
            {
                MessageBox.Show("Ingrese un NISS.");
                return;
            }

            CuentaModels cuenta = cuentaController.CargarDatos(niss);

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
            txtSaldo.Text = cuenta.Saldo.ToString(
                CultureInfo.CurrentCulture);
            dtpVencimiento.Value = cuenta.FechaVencimiento;
        }

        public bool ActualizarCuenta()
        {
            if (cuentaActual == null)
            {
                MessageBox.Show("Primero debe cargar una cuenta.");
                return false;
            }

            decimal saldo;

            if (!decimal.TryParse(
                txtSaldo.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out saldo))
            {
                MessageBox.Show("El saldo no tiene un formato válido.");
                return false;
            }

            cuentaActual.Niss = txtNiss.Text.Trim();
            cuentaActual.Nombre = txtNombre.Text.Trim();
            cuentaActual.Cedula = txtCedula.Text.Trim();
            cuentaActual.Telefono = txtTelefono.Text.Trim();
            cuentaActual.Correo = txtCorreo.Text.Trim();
            cuentaActual.Direccion = txtDireccion.Text.Trim();
            cuentaActual.Saldo = saldo;
            cuentaActual.FechaVencimiento = dtpVencimiento.Value;

            bool actualizado =
                cuentaController.ActualizarCuenta(cuentaActual);

            if (actualizado)
            {
                MessageBox.Show(
                    "La cuenta se actualizó correctamente.");
            }

            return actualizado;
        }

        public bool EliminarCuenta()
        {
            if (cuentaActual == null)
            {
                MessageBox.Show("Primero debe cargar una cuenta.");
                return false;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar esta cuenta?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return false;
            }

            bool eliminada =
                cuentaController.EliminarCuenta(cuentaActual);

            if (eliminada)
            {
                MessageBox.Show(
                    "La cuenta se eliminó correctamente.");

                cuentaActual = null;
                LimpiarControles();
            }

            return eliminada;
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos(txtNiss.Text);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCuenta();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCuenta();
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtSaldo.Clear();
            dtpVencimiento.Value = DateTime.Today;
        }
    }
}