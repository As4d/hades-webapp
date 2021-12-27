using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SqlRepository : IRepository
    {
        private readonly IConfiguration _configuration;

        public SqlRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int GetTotalNumberOfUsers()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sqlCommand = new SqlCommand("SELECT COUNT(UserId) FROM [User] WTIH (nolock)", connection);
            sqlCommand.Connection.Open();
            var noOfUsers = (int)sqlCommand.ExecuteScalar();

            return noOfUsers;
        }

        public int GetTotalNumberOfScans()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var sqlCommand = new SqlCommand("SELECT SUM(NumberOfScans) FROM [User] WTIH (nolock)", connection);
            sqlCommand.Connection.Open();
            var noOfScans = (int)sqlCommand.ExecuteScalar();

            return noOfScans;
        }

    }
}
