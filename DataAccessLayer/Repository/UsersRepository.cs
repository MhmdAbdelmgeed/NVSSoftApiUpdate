using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UsersRepository
    {
        private readonly string connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("LibraryConnection");
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = MapToUser(reader);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        private User MapToUser(SqlDataReader reader)
        {
            return new User
            {
                UserID = (int)reader["UserID"],
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                Age = (int)reader["Age"],
                PhoneNumber = reader["PhoneNumber"].ToString()
            };
        }
    }
}
