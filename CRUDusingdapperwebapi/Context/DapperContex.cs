using System.Data;
using System.Data.SqlClient;

namespace CRUDusingdapperwebapi.Context
{
    public class DapperContex
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContex(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");

        }
        public IDbConnection CreateConnection()
             => new SqlConnection(_connectionString);
    }
}
