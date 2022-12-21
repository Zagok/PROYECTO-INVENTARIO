using System;
using AccesoDatos;
using System.Windows.Forms;

namespace MANEJADORES
{
    public class ManejadorLogin
    {
        public AccesoBase _base;
        public ManejadorLogin()
        {
            _base = new AccesoBase("localhost", "root", "", "restauranteinventory", 3306);
        }
        public int Login(string lUsuario, string lContrasena)
        {
            string consulta = string.Format("SELECT count(*) FROM usuario WHERE NombreUsuario = '{0}' AND Contrasena = '{1}';", lUsuario, lContrasena);//1
            int c = int.Parse(_base.ConsultaRetorno(consulta));
            return c;
        }
        public int ValidarUsuario(string vUsuario, string vContrasena)
        {
            int c = 0;
            try//1
            {
                c = Login(vUsuario, vContrasena);//2
            }//1
            catch (Exception ex)//3
            {
                MessageBox.Show("Falló la validación " + ex.Message);//4
            }//3
            return c;//5
        }
    }
}
