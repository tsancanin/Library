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

    }
}
