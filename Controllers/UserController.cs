using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController:ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository=repository;
        }

        [HttpGet]
        public async Task<List<User>>GetAsync()
        {
            var result = await _repository.GetAsync();
            return result;
        }

       [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<User?>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto dto)
        {
            var us = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role,
                ProfilePicture = dto.ProfilePicture,
                Position = dto.Position,
                TeamId = dto.TeamId
            };

            var result = await _repository.CreateAsync(us);

            return CreatedAtRoute("GetUserById", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateAsync(int id,[FromBody] UpdateUserDto dto)
        {
            var us=new User
            {
                Name=dto.Name,
                Role=dto.Role,
                ProfilePicture=dto.ProfilePicture,
                Position=dto.Position
            };

            var result= await _repository.UpdateAsync(id,us);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}