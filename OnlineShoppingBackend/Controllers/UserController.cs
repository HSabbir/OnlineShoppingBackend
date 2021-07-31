using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingBackend.Dtos.User;
using OnlineShoppingBackend.Models;
using OnlineShoppingBackend.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
       
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

    
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> response = await _userService.UpdateUser(updatedUser);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetUserDto>> response = await _userService.DeleteUser(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


    }
}
