namespace ENTIDADES
{
    public class EntidadProductos
    {
        public EntidadProductos(int id, double cantidad)
        {
            _ID = id;
            _Cantidad = cantidad;
        }

        public EntidadProductos()
        {
        }

        public EntidadProductos(int id, int codigoBarras, string nombre, string descripcion, double cantidad, string fechaEntrada, string fKNombreUsuario)
        {
            _ID = id;
            _CodigoBarras = codigoBarras;
            _Nombre = nombre;
            _Descripcion = descripcion;
            _Cantidad = cantidad;
            _FechaEntrada = fechaEntrada;
            _FKNombreUsuario = fKNombreUsuario;
        }
        public int _ID { get; set; }
        public int _CodigoBarras { get; set; }
        public string _Nombre { get; set; }
        public string _Descripcion { get; set; }
        public double _Cantidad { get; set; }
        public string _FechaEntrada { get; set; }
        public string _FKNombreUsuario { get; set; }
    }
}
