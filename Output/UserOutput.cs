using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Model.Response;

namespace ITDiv_MiniProject.Output
{
    public class UserOutput
    {
        public ServerResponse Users { get; set; }
        public UserOutput() {
            this.Users = new ServerResponse();
        }

    }
}
