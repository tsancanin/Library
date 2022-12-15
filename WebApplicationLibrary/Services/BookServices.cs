using Microsoft.AspNetCore.Mvc;
using WebApplicationLibrary.Dto;
using WebApplicationLibrary.Entities;
using WebApplicationLibrary.Repository;

namespace WebApplicationLibrary.Services
{
    public class BookServices
    {
        private BookRepository bookRepository;

        public BookServices(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<DtoBook> GetAll()
        {
            var books = bookRepository.GetAll();
            var allBooks = new List<DtoBook>();
            foreach (var book in books)
            {
                allBooks.Add(new DtoBook()
                {
                    Id = book.Id,
                    Title = book.Title
                });
            }
            return allBooks;
        }

        public DtoBook BookGetById(int id)
        {
            var book = bookRepository.Get(id);
            if (book is null)
            {
                return null;
            }
            return new DtoBook()
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public CreateOrEditBook EditBook(int id, CreateOrEditBook editBook)
        {
            var book = new Book()
            {
                Id = id,
                Title = editBook.Title
            };
            bookRepository.Update(book);

            return new CreateOrEditBook()
            {
                Title = editBook.Title
            };
        }

        public DtoBook AddBook(int id, CreateOrEditBook create)
        {
            var book = new Book()
            {
                Id = id,
                Title = create.Title,
            };
            bookRepository.Create(book);
            return new DtoBook()
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public void DeleteBook(int id, CreateOrEditBook book)
        {
            var bookDelete = new Book()
            {
                Id = id,
                Title = book.Title
            };
            bookRepository.Delete(bookDelete);
        }
    }
}
