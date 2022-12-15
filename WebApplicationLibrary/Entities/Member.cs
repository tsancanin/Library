using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
