using WebApplicationLibrary.DataConnection;
using WebApplicationLibrary.Entities;

namespace WebApplicationLibrary.Repository
{
    public class BookRepository
    {
        private LibraryContext _libraryContext;

        public BookRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _libraryContext.Books.ToList();
        }
        public Book Get(int id)
        {
            return _libraryContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Book book)
        {
            _libraryContext.Books.Update(book);
            _libraryContext.SaveChanges();
        }

        public void Create(Book book)
        {
            _libraryContext.Books.Entry(book);
            _libraryContext.SaveChanges();
        }
        public void Delete(Book book)
        {
            _libraryContext.Books.Remove(book);
            _libraryContext.SaveChanges();
        }


    }
}
