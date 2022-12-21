namespace ENTIDADES
{
    public class EntidadLogin
    {
        public EntidadLogin(string usuario, string contrasena)
        {
            _Usuario = usuario;
            _Contrasena = contrasena;
        }

        public string _Usuario { get; set; }
        public string _Contrasena { get; set; }
    }
}
