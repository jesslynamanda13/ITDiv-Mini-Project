using ITDiv_MiniProject.Model.Response;

namespace ITDiv_MiniProject.Output
{
    public class CategoryOutput
    {
        public ServerResponse Categories { get; set; }
        public CategoryOutput()
        {
            this.Categories = new ServerResponse();
        }
    }
}
