using System;
using System.Windows.Forms;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmRotacion : Form
    {
        ManejadorProductos mp;
        public FrmRotacion()
        {
            mp = new ManejadorProductos();
            InitializeComponent();
        }
        void Actualizar()
        {
            if (lbMovimientos.SelectedIndex == 0)
            {
                mp.Rotacion(dtgDatos, txtBuscar.Text);
                dtgDatos.AutoResizeColumns();
            }
            else
            {
                if (lbMovimientos.SelectedIndex == 1)
                {
                    mp.Rotacion2(dtgDatos, txtBuscar.Text);
                    dtgDatos.AutoResizeColumns();
                }
            }
        }

        private void FrmRotacion_Load(object sender, EventArgs e)
        {
        }

        private void lbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
