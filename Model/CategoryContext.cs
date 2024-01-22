using Microsoft.EntityFrameworkCore;

namespace ITDiv_MiniProject.Model
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
