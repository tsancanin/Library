using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Entities;
using WebApplicationLibrary.Repository;

namespace WebApplicationLibrary.Services
{
    public class AuthorServices
    {
        private AuthorRepository _repository;

        public AuthorServices(AuthorRepository repository)
        {
            _repository = repository;
        }

        public List<Dtobject> GetAll()
        {
            var authors = _repository.GetAll();

            var listOfAthors = new List<Dtobject>();
            foreach (var author in authors)
            {
                listOfAthors.Add(new Dtobject()
                {
                    Id = author.Id,
                    Name = author.Name

                });
            }
            return listOfAthors;
        }

        public Dtobject GetById(int id)
        {
            var author = _repository.GetById(id);
            if (author is null)
            {
                return null;
            }
            return new Dtobject()
            {
                Id = author.Id,
                Name = author.Name
            };
        }
        public Dtobject CreateAuthor(int id, CreateOrEditDto create)
        {
            var author = new Author()
            {
                Id = id,
                Name = create.Name
            };
            _repository.CreateAuthor(author);

            return new Dtobject()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public CreateOrEditDto UpdateAuthor(int id, CreateOrEditDto edit)
        {
            var author = new Author()
            {
                Id = id,
                Name = edit.Name
            };
            _repository.UpdateAuthor(author);
            return new CreateOrEditDto()
            {
                Name = edit.Name,
            };
        }

        public void DeleteAuthor(int id, CreateOrEditDto name)
        {
            var author = new Author()
            {
                Id = id,
                Name = name.Name
            };
            _repository.Delete(author);
        }

    }
}
