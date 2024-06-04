using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceLayer;
using DataLayer;
using ServiceLayer.Model;
using DataLayer.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookServices _bookService;
        public BookController(BookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            var result = _bookService.getAllBooksDb();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookByIndex(int id)
        {
            var result = _bookService.getBookByIDDb(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook(BookDetail bookDetail)
        {
            _bookService.insertBookDetailDb(bookDetail);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook([FromQuery] int id, [FromQuery] String Author, [FromQuery] String Title, [FromQuery] String Genre)
        {
            var result = _bookService.updateBookDb(id, Author, Title, Genre);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBookFromIndex(int id)
        {
            var result = _bookService.deleteBookByIdDb(id);
            return Ok(result);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
