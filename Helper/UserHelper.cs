using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Model.Request;
using ITDiv_MiniProject.Model.Response;
using ITDiv_MiniProject.Service;

namespace ITDiv_MiniProject.Helper
{
    public class UserHelper
    {
        private readonly UserContext _userContext;
        public UserHelper(UserContext userContext)
        {
            _userContext = userContext;
        }
        public ServerResponse RegisterHelper(RegisterRequest request)
        {
            ServerResponse response = new ServerResponse();
            try
            {
                
                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                    var User = new User();
                    User.Name = request.Name;
                    User.Email = request.Email;
                    User.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);


                _userContext.Users.Add(User);
                    _userContext.SaveChanges();

                    response.statusCode = 200;
                    response.message = "Success";
                    response.success = true;
              
                    return response;
                
            }
            catch (Exception ex) {
                throw new Exception("An error occurred while registering the user: " + ex.Message);
            }
        }

        public LoginResponse LoginHelper(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {

                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                var user = _userContext.Users.FirstOrDefault(u => u.Email == request.Email);
                
                if (user == null)
                {
                    response.statusCode = 404; 
                    response.message = "User not found.";
                    response.success = false;
                    return response;
                }

                if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {

                    response.statusCode = 200;
                    response.success = true;
                    response.message = "User logged in!";
                    response.Id = user.Id;
                    response.Name = user.Name;

                }
                else
                {
                    response.statusCode = 401;
                    response.message = "Incorrect password.";
                    response.success = false;
                }

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while login the user: " + ex.Message);
            }
        }

     

    }
}
