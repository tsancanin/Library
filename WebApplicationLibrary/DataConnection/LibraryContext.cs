using Microsoft.EntityFrameworkCore;
using WebApplicationLibrary.Entities;

namespace WebApplicationLibrary.DataConnection
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
