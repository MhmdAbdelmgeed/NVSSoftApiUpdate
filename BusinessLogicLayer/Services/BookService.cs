using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BookService
    {
        private readonly BooksRepository booksRepository;

        public BookService(IConfiguration configuration)
        {
            this.booksRepository = new BooksRepository(configuration);
        }

        public List<Book> GetBooks()
        {
            return booksRepository.GetBooks();
        }

        public void UpdateBookAvailability(int bookId, bool isAvailable)
        {
            booksRepository.UpdateBookAvailability(bookId, isAvailable);
        }
    }
}
