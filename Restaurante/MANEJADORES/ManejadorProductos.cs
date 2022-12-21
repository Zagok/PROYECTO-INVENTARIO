using System;
using System.Windows.Forms;
using AccesoDatos;
using ENTIDADES;

namespace MANEJADORES
{
    public class ManejadorProductos
    {
        public AccesoBase _base;
        public ManejadorProductos()
        {
            _base = new AccesoBase("localhost", "root", "", "restauranteinventory", 3306);
        }

        public string Guardar(EntidadProductos p)
        {
            try//1
            {
                return _base.Consulta(string.Format("call p_Agregarproducto(null, {0},'{1}','{2}',{3},'{4}','{5}')", p._CodigoBarras, p._Nombre, p._Descripcion,
                p._Cantidad, p._FechaEntrada, p._FKNombreUsuario));//2
            }//1
            catch (Exception)//3
            {
                return "error";//4
            }//3
                
            
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = _base.Mostrar(string.Format("select * from productos where CodigoBarras like '%{0}%' or Nombre like '%{0}%'", dato), "productos").Tables["productos"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadProductos p)
        {
            try
            {
                return _base.Consulta(string.Format("call p_ModificarProductos({0},{1},'{2}','{3}',{4},'{5}','{6}')", p._ID, p._CodigoBarras, p._Nombre, p._Descripcion,
                p._Cantidad, p._FechaEntrada, p._FKNombreUsuario));
            }
            catch (Exception)
            {
                return "error";
            }
            
        }
        public string Borrar(EntidadProductos p)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + p._Nombre, "Atencion!", MessageBoxButtons.YesNo);//1
            if (rs == DialogResult.Yes)//2
            {
                r = _base.ConsultaRetorno(string.Format("call p_EliminarProducto('{0}')", p._CodigoBarras));//3
            }//2
            return r;//4
        }
        public string ModificarCantidad(EntidadProductos p)
        {
            return _base.Consulta(string.Format("call p_ModificarCantidad({0},{1})", p._ID, p._Cantidad));
        }
        public string GuardarMovimientos(EntidadMovimientos m)
        {
            return _base.Consulta(string.Format("call p_AgregarMovimiento(null, '{0}','{1}',{2})", m._Ingreso,
                m._FechaMovimiento, m._FKID));
        }
        public void MostrarMovimientos(DataGridView tabla, string dato)
        {
            tabla.DataSource = _base.Mostrar(string.Format("select CodigoBarras, Nombre, Descripcion, FechaEntrada, FKNombreUsuario, Ingreso, FechaMovimiento from productos, movimientos where movimientos.FKID = productos.id;", dato), "productos, movimientos").Tables["productos, movimientos"];
            tabla.AutoResizeColumns();
        }
        public string Guardarretiros(EntidadRetiros r)
        {
            return _base.Consulta(string.Format("call p_AgregarRetiro(null, '{0}','{1}',{2})", r._Retiros,
                r._FechaMovimiento, r._FKIDProd));
        }
        public void MostrarRetiros(DataGridView tabla, string dato)
        {
            tabla.DataSource = _base.Mostrar(string.Format("select CodigoBarras, Nombre, Descripcion, FechaEntrada, FKNombreUsuario, Retiros, FechaMovimiento from productos, retiros where retiros.FKIDProd = productos.id;", dato), "productos, retiros").Tables["productos, retiros"];
            tabla.AutoResizeColumns();
        }
        public void Rotacion(DataGridView tabla, string dato)
        {
            tabla.DataSource = _base.Mostrar(string.Format("select Retiros, FechaMovimiento as 'Fecha De Movimiento', FKIDProd as 'ID Produto', Nombre from retiros inner join productos on retiros.FKIDProd = productos.id order by Retiros desc;", dato), "retiros, productos").Tables["retiros, productos"];
            tabla.AutoResizeColumns();
        }
        public void Rotacion2(DataGridView tabla, string dato)
        {
            tabla.DataSource = _base.Mostrar(string.Format("select Retiros, FechaMovimiento as 'Fecha De Movimiento', FKIDProd as 'ID Produto', Nombre from retiros inner join productos on retiros.FKIDProd = productos.id order by Retiros asc;", dato), "retiros, productos").Tables["retiros, productos"];
        }
        public void RangoFechas(string inicio, string fin, DataGridView tabla)  
        {
            tabla.DataSource = _base.Mostrar(string.Format("select CodigoBarras, Nombre, Descripcion, FechaEntrada, FKNombreUsuario, Ingreso, FechaMovimiento from productos, movimientos where FechaMovimiento between '" + inicio + "' and '" + fin + "'"), "productos, movimientos").Tables["productos, movimientos"];
        }
    }
}