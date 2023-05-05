using Microsoft.EntityFrameworkCore;
using Notification.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Globalization;

namespace Notification.DAL
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        private readonly DataContext _context;



        public EmailRepository(IConfiguration configuration, DataContext context)

        {

            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString("SqlConnection");

            _context = context;

        }
       

            public async Task<bool> SaveEmail(MailRequest mailRequest)
            {

                using var connection = new SqlConnection(_connectionString);
                mailRequest.SentTime = DateTime.Now;
                var sql = $"INSERT INTO Email VALUES ('{mailRequest.To}', '{mailRequest.From}', '{mailRequest.Subject}', '{mailRequest.Body}', '{mailRequest.SentTime}' )";
                await connection.ExecuteAsync(sql, mailRequest);
                return true;
            }

        public async Task<IEnumerable<MailRequest>> GetAllEmails()
        {           
           
            var query = "SELECT * FROM Email";

            // Create a new SqlConnection object with the connection string
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<MailRequest>(query);
                
            }

        }
    }



}

        