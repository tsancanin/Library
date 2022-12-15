using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
