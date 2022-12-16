using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Entities;
using WebApplicationLibrary.Repository;

namespace WebApplicationLibrary.Services
{
    public class MemberServices
    {
        private MemberRepository _repository;

        public MemberServices(MemberRepository repository)
        {
            _repository = repository;
        }

        private Dtobject GetDto(Member member) => new Dtobject
        {
            Id = member.Id,
            Name = member.Name,
        };

        public List<Dtobject> GetAll()
        {
            return _repository.GetAll().Select(GetDto).ToList();
        }

        public Dtobject GetById(int id) 
        {
            var member = _repository.GetById(id);
            if (member is null)
            {
                return null;
            }
            return new Dtobject()
            {
                Id = member.Id,
                Name = member.Name,
            };
        }

        public Dtobject CreateMember(int id, CreateOrEditDto edit)
        {
            var member = new Member()
            {
                Id = id,
                Name = edit.Name,
            };

            _repository.Create(member);

            return new Dtobject()
            {
                Id = member.Id,
                Name = edit.Name,
            };
        }

        public CreateOrEditDto UpdateMember(int id, CreateOrEditDto edit)
        {
            var member = new Member()
            {
                Id = id,
                Name = edit.Name,
            };
            _repository.Update(member);

            return new CreateOrEditDto()
            {
                Name= edit.Name,
            };
        }

        public void DeleteMember(int id, CreateOrEditDto member)
        {
            var memberDto = new Member()
            {
                Id = id,
                Name = member.Name
            };
            _repository.Delete(memberDto);
        }
    }
}
