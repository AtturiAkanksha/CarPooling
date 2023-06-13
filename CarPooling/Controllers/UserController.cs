using CarPooling.DomainModels;
using Microsoft.AspNetCore.Mvc;
using CarPooling.API.RequestDTOs;
using CarPooling.API.ResponseDTOs;
using AutoMapper;
using CarPooling.Services.Contracts;

namespace CarPooling.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] UserRequest user)
        {
            try
            {
                return Ok(new ResponseBase<User>()
                {
                    Response = await _userService.CreateUser(_mapper.Map<User>(user)),
                    Message = "success"
                });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseBase<bool>()
                {
                    Response = false,
                    Message = ex.Message
                });

            }

        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(DataObject), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser([FromBody] UserRequest userRequest)
        {
            try
            {
                User user = await _userService.GetUser(_mapper.Map<User>(userRequest));
                var dataObject = new DataObject
                {
                    Token = _tokenService.GenerateToken(),
                    UserId = user.Id
                };
                return Ok(dataObject);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

    }

}
