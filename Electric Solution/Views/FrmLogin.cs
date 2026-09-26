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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        UsuarioControllers usuario = new UsuarioControllers();

        //Abre Formulario de Registro de Cliente
        private void TxtRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            Hide();
            frmRegistro.ShowDialog();
            Show();
        }

        //Boton Salir
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string Niss = TxtUsuario.Text;
            string Contraseña = TxtContraseña.Text;
            if(string.IsNullOrEmpty(Niss) || string.IsNullOrEmpty(Contraseña))
            {
                MessageBox.Show("Por favor verifique los Datos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUsuario.Focus();
                return;
            }
            UsuarioControllers u = new UsuarioControllers();
            bool ok = u.IniciarSesion(Niss, Contraseña);
            
            if (!ok)
            {
                MessageBox.Show("Usuario o Contraseña no Válidos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtUsuario.Focus();
                return;
            }
            using(var frm=new FrmPrincial())
            {
                Hide();
                frm.ShowDialog();
                Show();
            }
            TxtUsuario.Clear();
            TxtContraseña.Clear();
        }
    }
}
