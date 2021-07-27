using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public class DbConnectionBuilder : IDbConnectionBuilder
    {
        private readonly string _connectionString;

        public DbConnectionBuilder(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
