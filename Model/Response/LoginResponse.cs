namespace ITDiv_MiniProject.Model.Response
{
    public class LoginResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Boolean? success { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
