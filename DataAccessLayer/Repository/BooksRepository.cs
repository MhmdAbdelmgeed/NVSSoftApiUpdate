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

    public class BooksRepository
    {
        private readonly string connectionString;

        public BooksRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("LibraryConnection");
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Books";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = MapToBook(reader);
                        books.Add(book);
                    }
                }
            }

            return books;
        }

        public void UpdateBookAvailability(int bookId, bool isAvailable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Books SET Availability = @IsAvailable WHERE BookID = @BookID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    command.Parameters.AddWithValue("@BookID", bookId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private Book MapToBook(SqlDataReader reader)
        {
            return new Book
            {
                BookID = (int)reader["BookID"],
                Title = reader["Title"].ToString(),
                Author = reader["Author"].ToString(),
                ISBN = reader["ISBN"].ToString(),
                Availability = (bool)reader["Availability"]
            };
        }
    }

}
