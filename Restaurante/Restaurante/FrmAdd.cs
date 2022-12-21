using System;
using System.Windows.Forms;
using MANEJADORES;
using ENTIDADES;

namespace Restaurante
{
    public partial class FrmAdd : Form
    {
        ManejadorProductos mp;
        public FrmAdd()
        {
            mp = new ManejadorProductos();
            InitializeComponent();
            if (FrmCrud.ep._ID != 0)
            {
                txtCodigoBarras.Text = FrmCrud.ep._CodigoBarras.ToString();
                txtNombre.Text = FrmCrud.ep._Nombre;
                txtDescripcion.Text = FrmCrud.ep._Descripcion;
                txtCantidad.Text = FrmCrud.ep._Cantidad.ToString();
                txtFecha.Text = FrmCrud.ep._FechaEntrada;
                txtUsuario.Text = FrmCrud.ep._FKNombreUsuario;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (FrmCrud.ep._ID == 0)//1
            {
                
                MessageBox.Show(mp.Guardar(new EntidadProductos(FrmCrud.ep._ID, int.Parse(txtCodigoBarras.Text), txtNombre.Text, txtDescripcion.Text, double.Parse(txtCantidad.Text), DateTime.Today.ToString(), txtUsuario.Text)));//2

                this.Hide();
            }//1
            
            else//3
            {
                MessageBox.Show(mp.Editar(new EntidadProductos(FrmCrud.ep._ID, int.Parse(txtCodigoBarras.Text), txtNombre.Text, txtDescripcion.Text, double.Parse(txtCantidad.Text), txtFecha.Text, txtUsuario.Text)));//4
                mp.GuardarMovimientos(new EntidadMovimientos(FrmCrud.em._IDMovimientos, txtCantidad.Text, DateTime.Today.ToString(), FrmCrud.ep._ID));
            }//3
            this.Hide();//5
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            if (FrmCrud.ep._ID == 0)
            {
                txtFecha.Text = DateTime.Today.ToString();
            }
        }
    }
}
