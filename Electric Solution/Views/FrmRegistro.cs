using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electric_Solution.Controllers;

namespace Electric_Solution
{
    public partial class FrmRegistro : Form
    {
        private readonly ClienteControllers clienteControllers = new ClienteControllers();
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void LbIniciar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            Hide();
            frmLogin.ShowDialog();
            Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = TxtNombre.Text;
            string Cedula = TxtCedula.Text;
            string NumeroNiss = TxtNiss.Text;
            string Correo = TxtCorreo.Text;
            string Telefono = TxtTelefono.Text;
            string Direccion = TxtDirección.Text;
            string Contraseña = TxtContraseña.Text;
            string ConfContraseña = TxtConfirContraseña.Text;
            if (!ValidarTextBoxes(this))
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución si hay campos vacíos
            }

            // Si pasa la validación, el código continúa aquí...
            MessageBox.Show("¡Todos los campos están llenos! Procesando información...", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (Contraseña == ConfContraseña || RbtnAceptar.Checked == true)
            {
                clienteControllers.Guardar(Nombre, Cedula, NumeroNiss, Correo, Telefono, Direccion, Contraseña);
                MessageBox.Show("Se ha registrado Correctamente.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ingrese sus datos para Ingresar", "Cliente", MessageBoxButtons.OK);
            }
        }
        private void Limpiar()
        {
            TxtNombre.Clear();
            TxtCedula.Clear();
            TxtNiss.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
            TxtDirección.Clear();
            TxtContraseña.Clear();
            TxtConfirContraseña.Clear();
        }
        private bool ValidarTextBoxes(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                // Si el control es un TextBox, verificamos si está vacío
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Focus(); // Pone el cursor en el TextBox vacío
                        return false;    // Retorna falso inmediatamente
                    }
                }

                // IMPORTANTE: Si el control tiene subcontroles (como un GroupBox o Panel), los revisa recursivamente
                if (control.HasChildren)
                {
                    if (!ValidarTextBoxes(control))
                    {
                        return false;
                    }
                }
            }
            return true; // Todos los TextBox tienen texto
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Ruta del archivo PDF (puede ser local o una URL web)
                string rutaPDF =@"D:\Proyecto\Electric Solution1.2\Electric Solution\TÉRMINOS Y CONDICIONES DE USO.pdf";
                
                // Configuración para que el sistema operativo maneje la apertura
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true // Requerido en .NET Core / .NET 5+ para abrir archivos externos
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo PDF. Asegúrese de tener un lector instalado. " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
