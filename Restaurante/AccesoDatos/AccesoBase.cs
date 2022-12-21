using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AccesoBase
    {
        MySqlConnection _conn;
        public MySqlCommand command;
        public AccesoBase(string server, string user, string password, string based, uint port)
        {
            _conn = new MySqlConnection(string.Format("server={0}; user={1}; password={2}; database = {3}; port = {4}", server, user, password,
                based, port));
        }

        public string Consulta(string q)
        {
            try
            {
                command = new MySqlCommand(q, _conn);
                _conn.Open();
                command.ExecuteNonQuery();
                _conn.Close();
                return "Correcto";
            }
            catch (Exception ex)
            {
                _conn.Close();

                return ex.Message;
            }
        }
        public string ConsultaRetorno(string q)
        {
            _conn.Open();

            var command = new MySqlCommand(q, _conn);
            command.ExecuteNonQuery();
            string v = Convert.ToString(command.ExecuteScalar());

            _conn.Close();
            return v;
        }

        public DataSet Mostrar(string consulta, string tabla)
        {
            var ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, _conn);
                _conn.Open();
                da.Fill(ds, tabla);
                _conn.Close();
                return ds;
            }
            catch (Exception)
            {
                _conn.Close();
                return ds;
            }
        }
    }
}
