using System.ComponentModel.DataAnnotations;

namespace ITDiv_MiniProject.Model.Request
{
    public class CategoryRequest
    {
        [Required] public string Name { get; set; }
    }
}
