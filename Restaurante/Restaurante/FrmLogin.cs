using System;
using System.Windows.Forms;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml;
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public static string userAdmin, passAdmin;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
             
            userAdmin = txtUser.Text;
            passAdmin = txtPass.Text;
            int v = ml.ValidarUsuario(txtUser.Text, txtPass.Text);
            if (v == 1)
            {

                this.Hide();
                FrmPrincipal fp = new FrmPrincipal();
                fp.Show();
            }
            else
            {
                MessageBox.Show("Error, Usuario y/o Contraseña Incorrectos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
