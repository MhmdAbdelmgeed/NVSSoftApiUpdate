using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NVSSoft.Controllers
{
 
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService bookService;

        public BooksController(IConfiguration configuration)
        {
            this.bookService = new BookService(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = bookService.GetBooks();
            return Ok(books);
        }

        [HttpPut("update-availability/{bookId}")]
        public IActionResult UpdateBookAvailability(int bookId, [FromBody] bool isAvailable)
        {
            try
            {
                bookService.UpdateBookAvailability(bookId, isAvailable);
                return Ok($"Book availability updated for BookID: {bookId}");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
