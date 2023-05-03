using Microsoft.EntityFrameworkCore;
using Notification.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Notification.DAL
{
    public class EmailRepository : IEmailRepository
    {
      private readonly IConfiguration _configuration;

        private readonly string _connectionString;



        public EmailRepository(IConfiguration configuration)

        {

            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString("SqlConnection");

        }



        public async Task<bool> SaveEmail(MailRequest mailRequest) 
        {

            using var connection = new SqlConnection(_connectionString);
            var sql = $"INSERT INTO Email VALUES ('{mailRequest.To}', '{mailRequest.From}', '{mailRequest.Subject}', '{mailRequest.Body}')";
            await connection.ExecuteAsync(sql, mailRequest );
            return false;
        } 
    }
}