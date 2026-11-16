using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electric_Solution.Views.User;

namespace Electric_Solution.Views
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        // Método para cargar un UserControl dentro de un Panel contenedor
        
        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar
            
            Inicioprincipal ucInicio = new Inicioprincipal();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(ucInicio);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir del sistema?",
                                           "Confirmar salida",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // O usar this.Close(); según corresponda
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar

            Uc_Consulta uc_Consulta = new Uc_Consulta();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(uc_Consulta);

        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar

             Uc_Pago uc_Pago = new Uc_Pago();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(uc_Pago);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar

            Uc_Reporte uc_Reporte = new Uc_Reporte();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(uc_Reporte);
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar

            Uc_Seguimiento uc_Seguimiento = new Uc_Seguimiento();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(uc_Seguimiento);
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            // Instanciar el Control de Usuario que deseas mostrar

           Uc_Cuenta uc_Cuenta = new Uc_Cuenta();

            // Llamar al método para cargarlo en el panel contenedor
            MostrarUserControl(uc_Cuenta);
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            Inicioprincipal inicio = new Inicioprincipal();

            MostrarUserControl(inicio);
        }

        private void MostrarUserControl(UserControl uc)
        {
            panel2.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);

            uc.BringToFront();
        }
    }
}
