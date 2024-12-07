﻿using CoreDomain.Users;
using Microsoft.Data.SqlClient;

namespace SeniorConnect.DataAccesLibrary
{
    public class DataAccess
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SeniorConnect.SQLServerDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Command Timeout=0";
        private static SqlConnection OpenSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public SqlConnection OpenSqlConnection()
        {
            return OpenSqlConnection(_connectionString);
        }
    }
}
