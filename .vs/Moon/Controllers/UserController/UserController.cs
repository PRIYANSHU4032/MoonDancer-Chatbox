using Microsoft.AspNetCore.Mvc;
using Moon.DTOs;
using Moon.User_Op;

namespace Moon.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserGenralManger _userGenralManger;
        public UserController(UserGenralManger userGenralManger)
        {
            _userGenralManger = userGenralManger;
        }


        [HttpPost("createMoonUser")]
        public Guid createMoonUser([FromBody] User user)
        {
           return _userGenralManger.createUser(user);
        }

        [HttpGet("getMoonUsers")]
        public List<User> getMoonUsers() { 
            return _userGenralManger.getALLUsers();
        }
    }
}
