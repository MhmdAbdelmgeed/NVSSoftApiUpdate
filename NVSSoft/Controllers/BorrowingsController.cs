using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NVSSoft.Controllers
{
    [ApiController]
    [Route("api/borrowings")]
    public class BorrowingsController : ControllerBase
    {
        private readonly BorrowingsService borrowingsService;

        public BorrowingsController(IConfiguration configuration)
        {
            this.borrowingsService = new BorrowingsService(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Borrowing>> GetBorrowings()
        {
            var borrowings = borrowingsService.GetBorrowings();
            return Ok(borrowings);
        }
    }

}
