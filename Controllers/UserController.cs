using CarPooling.Models ;
using CarPooling.Services;
using Microsoft.AspNetCore.Mvc;
using CarPooling.RequestDTOs;
using CarPooling.ResponseDTOs;


namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRequest user)
        {
            try
            {
                return Ok(new ResponseBase<User>() { 
                   Response =  await _userService.CreateUser(user),
                   Message = "success"
                });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseBase<bool>() {
                    Response = false,
                    Message = "unKonown"
                });

            }

        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> getUsers()
        {
            try
            {
             List<User> getUsers =await  _userService.GetUsers();
                return Ok(getUsers);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserRequest user)
        {
            try
            {
               LoginObject loginObject=await  _userService.Login(user);
                return Ok(loginObject);
               
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

    }

}
