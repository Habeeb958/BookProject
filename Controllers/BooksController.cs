using Microsoft.AspNetCore.Mvc;
using BookProject.Data; // Ensure this namespace is correct for your context
using BookProject.Models; // Ensure this namespace is correct for your models
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    [ApiController]
    [Route("api/v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        // Endpoint to retrieve a book by ID
        [HttpGet("{book_id}")]
        public async Task<IActionResult> GetBookById(int book_id)
        {
            // Search for the book in the database
            var book = await _context.Books.FindAsync(book_id);

            if (book == null)
            {
                // If the book is not found, return a 404 response
                return NotFound(new { detail = "Book not found" });
            }

            // If the book is found, return it as a JSON response
            return Ok(book);
        }
    }
}
