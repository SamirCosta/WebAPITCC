using MySql.Data.MySqlClient;
using System;

namespace WebAPITCC.Models
{
    public class ConexaoDB : IDisposable
    {
        private readonly MySqlConnection conexao;
        public ConexaoDB()
        {
            //conexao = new MySqlConnection("server=localhost;user id=root;password=12345678;database=db_REST");
            conexao = new MySqlConnection("Database=db_REST; Data Source=webapitccserver.mysql.database.azure.com; User Id=tecBridge@webapitccserver; Password=WebAPITCC1");
            conexao.Open();
        }

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaRegistro(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteReader();
        }

        public object RetornaDado(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteScalar();
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

    }
}