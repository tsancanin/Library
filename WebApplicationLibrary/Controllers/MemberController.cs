using Microsoft.AspNetCore.Mvc;
using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Services;

namespace WebApplicationLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberServices _service;

        public MemberController(MemberServices service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]

        public ActionResult<Dtobject> GetAll()
        {
            var allMambers = _service.GetAll();
            return Ok(allMambers);
        }

        [HttpGet("GetById")]
        public ActionResult<Dtobject> GetById(int id)
        {
            var member = _service.GetById(id);
            return Ok(member);
        }

        [HttpPut("Edit")]

        public ActionResult<Dtobject> EditMember(int id, CreateOrEditDto member)
        {
            var edit = _service.UpdateMember(id, member);
            return Ok(edit);
        }

        [HttpPost("AddMember")]

        public ActionResult<Dtobject> AddMember(int id, CreateOrEditDto member)
        {
            var newMember = _service.CreateMember(id,member);
            return Ok(newMember);
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteMember(int id,CreateOrEditDto member)
        {
            _service.DeleteMember(id, member);
            return Ok();
        }


    }
}
