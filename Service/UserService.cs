using ITDiv_MiniProject.Helper;
using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Model.Request;
using ITDiv_MiniProject.Model.Response;
using ITDiv_MiniProject.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITDiv_MiniProject.Service
{
    public class UserService : ControllerBase
    {
        public UserHelper _userHelper;

        public UserService(UserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpPost]
        [Route("api/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserRegister([FromBody] RegisterRequest request)
        {
           
            UserOutput userOutput = new UserOutput();

            try
            {
                userOutput.Users = _userHelper.RegisterHelper(request);
                if (userOutput.Users.statusCode == 200)
                {
                    return new OkObjectResult(userOutput.Users);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new UserOutput
                {
                    Users = new ServerResponse
                    {
                        statusCode = 500,
                        message = "An error occurred while adding user."
                    }
                };
                return new ObjectResult(errorResponse.Users)
                {
                    StatusCode = errorResponse.Users.statusCode
                };
            }
            var specificErrorResponse = new UserOutput
            {
                Users = new ServerResponse
                {
                    statusCode = 400,
                    message = "User add failed due to a specific reason."
                }
            };
            return new ObjectResult(specificErrorResponse.Users)
            {
                StatusCode = specificErrorResponse.Users.statusCode
            };
           
        }

        [HttpPost]
        [Route("api/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UserLogin([FromBody] LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            //UserOutput userOutput = new UserOutput();
            response = _userHelper.LoginHelper(request);
            return new OkObjectResult(response);
        }



            

    }
}
