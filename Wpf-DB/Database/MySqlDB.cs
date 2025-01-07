using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_DB.Database
{
    public class MySqlDB
    {
        private readonly string _connectionString;
        private MySqlConnection? _connection;

        public MySqlDB(string connectionString)
        {
            this._connectionString = connectionString;
        }

        private void Connect()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }
    }
}
