using System.ComponentModel.DataAnnotations;

namespace ITDiv_MiniProject.Model
{
    public class Category
    {
        [Key]

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
