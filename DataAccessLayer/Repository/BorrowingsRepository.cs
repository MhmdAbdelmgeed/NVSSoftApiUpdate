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
    public class BorrowingsRepository
    {
        private readonly string connectionString;

        public BorrowingsRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("LibraryConnection");
        }

        public List<Borrowing> GetBorrowings()
        {
            List<Borrowing> borrowings = new List<Borrowing>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Borrowings";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Borrowing borrowing = MapToBorrowing(reader);
                        borrowings.Add(borrowing);
                    }
                }
            }

            return borrowings;
        }

        private Borrowing MapToBorrowing(SqlDataReader reader)
        {
            return new Borrowing
            {
                BorrowingID = (int)reader["BorrowingID"],
                UserID = (int)reader["UserID"],
                BookID = (int)reader["BookID"],
                BorrowDate = (DateTime)reader["BorrowDate"],
                ReturnDate = reader["ReturnDate"] as DateTime?,
                Returned = (bool)reader["Returned"]
            };
        }
    }
}
