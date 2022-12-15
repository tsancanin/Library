using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
