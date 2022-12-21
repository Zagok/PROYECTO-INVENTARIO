using System;
using System.Windows.Forms;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmPrincipal : Form
    {
        ManejadorLogin ml;
        public FrmPrincipal()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void tmrHoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = FrmLogin.userAdmin;
        }
        public static Form frmactivo = null;
        public static Form frmhijo;

        public void AbrirFrmHijo(Form frmhijo)
        {

            if (frmactivo != null)
            {
                frmactivo.Close();
            }
            frmactivo = frmhijo;
            frmhijo.TopLevel = false;
            frmhijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(frmhijo);
            pnlContenedor.Tag = frmhijo;
            frmhijo.BringToFront();
            frmhijo.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FrmCrud());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FrmMovimientos());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FrmRotacion());
        }
    }
}
