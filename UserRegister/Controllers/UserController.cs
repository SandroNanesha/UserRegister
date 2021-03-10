using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UserRegister.Model;
using UserRegister.Services;
using UserRegister.Validators;

namespace UserRegister.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserControllerService _userService;

        public UserController(IUserControllerService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}/{password}")]
        public IActionResult Get(string id, string password)
        {
            return Ok(_userService.Get(id, password));
        }

        [HttpPost("{id}/{password}/{email}/{tele}")]
        public IActionResult AddUser(string id, string password, string email, string tele)
        {
            return Ok(_userService.AddUser(id, password, email, tele));
        }

        [HttpPut]
        public IActionResult UpdateInfo(User currUser)
        {
            return Ok(_userService.UpdateInfo(currUser));
        }

        [HttpDelete]
        public IActionResult DeleteUser(User currUser)
        {
            return Ok(_userService.DeleteUser(currUser));
        }

    }
}
