using Microsoft.AspNetCore.Mvc;
using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Services;

namespace WebApplicationLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookServices _book;

        public BookController(BookServices book)
        {
            _book = book;
        }

        [HttpGet("GetAll")]

        public ActionResult<DtoBook> GetAll()
        {
            var allBooks = _book.GetAll();
            return Ok(allBooks);
        }

        [HttpGet("GetById")]

        public ActionResult<DtoBook> GetById(int id)
        {
            var book = _book.BookGetById(id);
            return Ok(book);
        }

        [HttpPut("EditBook")]

        public ActionResult<DtoBook> UpdateBook (int id, CreateOrEditBook book)
        {
            var updateBook = _book.EditBook(id, book);
            return Ok(updateBook);

        }

        [HttpPost("AddBook")]

        public ActionResult<DtoBook> AddBook(int id,CreateOrEditBook book)
        {
            var newBook = _book.CreateBook(id, book);
            return Ok(newBook);
        }

        [HttpDelete("Delete")]

        public ActionResult DeleteBook(int id, CreateOrEditBook book)
        {
            _book.DeleteBook(id, book);
            return Ok();
        }
    }
}
