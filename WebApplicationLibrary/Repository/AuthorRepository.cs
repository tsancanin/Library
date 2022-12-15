using WebApplicationLibrary.DataConnection;
using WebApplicationLibrary.Entities;

namespace WebApplicationLibrary.Repository
{
    public class AuthorRepository
    {
        private LibraryContext _dbContext;

        public AuthorRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors.ToList();
        }
        public Author GetById(int id)
        {
            return _dbContext.Authors.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
        }
        public void Delete(Author author)
        {
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }

    }
}
