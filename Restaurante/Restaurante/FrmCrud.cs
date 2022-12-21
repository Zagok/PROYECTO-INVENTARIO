using System;
using System.Windows.Forms;
using ENTIDADES;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmCrud : Form
    {
        public static EntidadProductos ep;
        public static EntidadMovimientos em;
        public static EntidadRetiros er;
        ManejadorProductos mp;
        int i = 0;
        public FrmCrud()
        {
            ep = new EntidadProductos();
            mp = new ManejadorProductos();
            em = new EntidadMovimientos();
            er = new EntidadRetiros();
            InitializeComponent();
        }
        void Actualizar()
        {
            mp.Mostrar(dtgDatos, txtBuscar.Text);
        }

        private void FrmCrud_Load(object sender, EventArgs e)
        {
            
            dtgDatos.AutoResizeColumns();
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                ep._ID = int.Parse(dtgDatos.CurrentRow.Cells["id"].Value.ToString());
                ep._CodigoBarras = int.Parse(dtgDatos.CurrentRow.Cells["CodigoBarras"].Value.ToString());
                ep._Nombre = dtgDatos.CurrentRow.Cells["Nombre"].Value.ToString();
                ep._Descripcion = dtgDatos.CurrentRow.Cells["Descripcion"].Value.ToString();
                ep._Cantidad = double.Parse(dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString());
                ep._FechaEntrada = dtgDatos.CurrentRow.Cells["FechaEntrada"].Value.ToString();
                ep._FKNombreUsuario = dtgDatos.CurrentRow.Cells["FKNombreUsuario"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ep._ID = 0;
            ep._CodigoBarras = 0;
            ep._Nombre = "";
            ep._Descripcion = "";
            ep._Cantidad = 0;
            ep._FechaEntrada = "";
            ep._FKNombreUsuario = "";
            FrmAdd fa = new FrmAdd();
            fa.ShowDialog();
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmAdd fa = new FrmAdd();
            fa.ShowDialog();
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgDatos.RowCount > 0)//1
            {
                string r = mp.Borrar(ep);
                mp.Mostrar(dtgDatos, "");
                if (string.IsNullOrEmpty(r))//2
                {
                    MessageBox.Show(r);//3
                    mp.Mostrar(dtgDatos, "");
                }//2
            }//1
            else//4
            {
                MessageBox.Show("Debe elegir un registro");//5
            }//4
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FrmRetirar fr = new FrmRetirar();
            fr.ShowDialog();
            Actualizar();
        }
    }
}
