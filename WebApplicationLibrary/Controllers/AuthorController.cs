using Microsoft.AspNetCore.Mvc;
using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Services;

namespace WebApplicationLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorServices _authorServices;

        public AuthorController(AuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet("GetAll")]

        public ActionResult<Dtobject> GetAuthors()
        {
            var authors = _authorServices.GetAll();
            return Ok(authors);
        }

        [HttpGet("GetById")]

        public ActionResult<Dtobject> GetById(int id)
        {
            var author = _authorServices.GetById(id);
            return Ok(author);
        }

        [HttpPut("Edit")]

        public ActionResult<Dtobject> Update(int id, CreateOrEditDto edit)
        {
            var editAuthor = _authorServices.UpdateAuthor(id, edit);
            return Ok(editAuthor);
        }

        [HttpPost("Add")]

        public ActionResult<Dtobject> AddAuthor(int id, CreateOrEditDto create)
        {
            var createAuthor = _authorServices.CreateAuthor(id, create);
            return Ok(createAuthor);
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id, CreateOrEditDto author)
        {
            _authorServices.DeleteAuthor(id, author);
            return Ok();
        }
    }
}
