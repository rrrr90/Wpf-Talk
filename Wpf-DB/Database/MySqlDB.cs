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
            Connect();
        }

        private void Connect()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        public long Execute(string query, SqlParameter[]? parms = null)
        {
            using MySqlCommand cmd = new MySqlCommand(query, _connection);
            if (parms != null)
            {
                foreach (SqlParameter parm in parms)
                {
                    cmd.Parameters.AddWithValue(parm.ParameterName, parm.Value);
                }
            }
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }
    }
}
