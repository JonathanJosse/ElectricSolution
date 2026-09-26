using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string Correo = TxtCedula.Text;
            string Telefono = TxtTelefono.Text;
            string Direccion = TxtDirección.Text;
            string Contraseña = TxtContraseña.Text;
            string ConfContraseña = TxtConfirContraseña.Text;
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
    }
}
