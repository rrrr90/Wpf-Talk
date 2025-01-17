﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_DB.Database
{
    public class MySqlDB : IDisposable
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
            AddParameters(cmd, parms);
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public IDataReader GetReader(string query, SqlParameter[]? parms = null)
        {
            using MySqlCommand cmd = new MySqlCommand(query, _connection);
            AddParameters(cmd, parms);
            return cmd.ExecuteReader();
        }

        public DataTable GetDataTable(string query, SqlParameter[]? parms = null)
        {
            using MySqlCommand cmd = new MySqlCommand(query, _connection);
            AddParameters(cmd, parms);
            using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void AddParameters(MySqlCommand cmd, SqlParameter[]? parms)
        {
            if (parms != null)
            {
                foreach (SqlParameter parm in parms)
                {
                    cmd.Parameters.AddWithValue(parm.ParameterName, parm.Value);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }
    }
}
