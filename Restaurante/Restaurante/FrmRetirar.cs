using System;
using System.Windows.Forms;
using ENTIDADES;
using MANEJADORES;

namespace Restaurante
{
    public partial class FrmRetirar : Form
    {
        EntidadProductos ep;
        ManejadorProductos mp;
        public FrmRetirar()
        {
            ep = new EntidadProductos();
            mp = new ManejadorProductos();
            InitializeComponent();
        }
        void Actualizar()
        {
            mp.Mostrar(dtgDatos, txtBuscar.Text);
        }

        private void FrmRetirar_Load(object sender, EventArgs e)
        {
            dtgDatos.AutoResizeColumns();
            Actualizar();
            //txtRetirar.Text = 0.ToString();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int i = 0;
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblExistencia.Text = ep._Cantidad.ToString();
        }

        private void txtRetirar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtRetirar.Text == "")
                {
                    lblRetiro.Text = 0.ToString();
                }
                else
                {
                    lblRetiro.Text = txtRetirar.Text;
                    if((txtRetirar.Text == "") || (lblRetiro.Text == 0.ToString()))
                    {
                        lblPorRetirar.Text = 0.ToString();
                    }
                    else
                    {
                        double rs = ep._Cantidad - double.Parse(lblRetiro.Text);
                        lblPorRetirar.Text = rs.ToString();
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("El valor debe de ser numerico");
            }
            
            /*double rs = double.Parse(lblExistencia.Text) - double.Parse(lblPorRetirar.Text);
            lblPorRetirar.Text = rs.ToString();*/

        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (lblRetiro.Text.Length == lblExistencia.Text.Length)
                {
                    DialogResult rs = MessageBox.Show("Si selecciona todos los productos dejará el almacén sin stock", "Desea continuar?", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        MessageBox.Show(mp.ModificarCantidad(new EntidadProductos(FrmCrud.ep._ID, double.Parse(lblPorRetirar.Text))));
                    mp.Guardarretiros(new EntidadRetiros(FrmCrud.er._IDRetiros, lblRetiro.Text, DateTime.Today.ToString(), FrmCrud.ep._ID));
                }
                    this.Hide();
                }
                else
                {
                    if (lblRetiro.Text.Length < lblExistencia.Text.Length)
                    {
                        MessageBox.Show(mp.ModificarCantidad(new EntidadProductos(FrmCrud.ep._ID, double.Parse(lblPorRetirar.Text))));
                    mp.Guardarretiros(new EntidadRetiros(FrmCrud.er._IDRetiros, lblRetiro.Text, DateTime.Today.ToString(), FrmCrud.ep._ID));
               
                    }
                this.Hide();
            }   
        }

        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            ep._ID = int.Parse(dtgDatos.CurrentRow.Cells["id"].Value.ToString());
            ep._Cantidad = double.Parse(dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString());
        }
    }
}
