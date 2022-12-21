using System;
using System.Windows.Forms;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmMovimientos : Form
    {
        ManejadorProductos mp;
        public FrmMovimientos()
        {
            mp = new ManejadorProductos();
            InitializeComponent();
        }

        void Actualizar()
        {
            
            if (lbMovimientos.SelectedIndex == 0)
            {
                mp.MostrarMovimientos(dtgDatos, txtBuscar.Text);
                dtgDatos.AutoResizeColumns();

            }
            else
            {
                if(lbMovimientos.SelectedIndex == 1)
                {
                    mp.MostrarRetiros(dtgDatos, txtBuscar.Text);
                    dtgDatos.AutoResizeColumns();
                }
            }
        }

        private void FrmMovimientos_Load(object sender, EventArgs e)
        {
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void lbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dpInicio_onValueChanged(object sender, EventArgs e)
        {
            CargarFecha();
        }

        private void dpFinal_onValueChanged(object sender, EventArgs e)
        {
            CargarFecha();
        }
        void CargarFecha()
        {
        }
    }
}
