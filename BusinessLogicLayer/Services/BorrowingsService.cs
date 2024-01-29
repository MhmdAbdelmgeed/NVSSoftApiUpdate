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
    public class BorrowingsService
    {
        private readonly BorrowingsRepository borrowingsRepository;

        public BorrowingsService(IConfiguration configuration)
        {
            this.borrowingsRepository = new BorrowingsRepository(configuration);
        }

        public List<Borrowing> GetBorrowings()
        {
            return borrowingsRepository.GetBorrowings();
        }
    }
}
