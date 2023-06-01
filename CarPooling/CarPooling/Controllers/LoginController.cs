﻿using CarPooling.Data;
using CarPooling.Models ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarPooling.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class LoginController : Controller
    {
        private readonly CarPoolingDbContext dbContext;
        private IConfiguration _config;
        public LoginController(CarPoolingDbContext dbContext, IConfiguration configuration) {
            this.dbContext = dbContext;
            _config = configuration;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> AddUser(UserRequest addUserRequest)
        {
            var user = new User()
            {
                email = addUserRequest.email,
                password = addUserRequest.password,
            };
            var isEmailAlreadyExists =  dbContext.Users.Any(x => x.email == user.email);
            if (isEmailAlreadyExists)
            {
                return BadRequest("email already exists");
            }
            else
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
        }

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> getUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }

        private string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);   

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt: Andience"],null,
                expires:DateTime.Now.AddDays(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> Login(UserRequest addUserRequest)
        {
            IActionResult response = Unauthorized();
            var existingUser = dbContext.Users.FirstOrDefault(x => x.email == addUserRequest.email);
            if (existingUser != null && existingUser.password == addUserRequest.password)
            { 
               var  token = GenerateToken();
                var loginObject = new LoginObject {
                    NewToken =Convert.ToString( new {token}),
                    UserId = existingUser.id
                };
                response =   Ok(loginObject);
                return response;
            }
            else if (existingUser != null && existingUser.password != addUserRequest.password)
            {
                return BadRequest("incorrect password");
            }
            return NotFound("User doesn't exists");
            
        }


    }

}
