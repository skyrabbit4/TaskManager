using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _repository;
        public OrganizationsController(IOrganizationRepository repository)
        {
          _repository=repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var organizations =await _repository.GetAllAsync();
            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
           var result= await _repository.GetByIdAsync(id);
            if (result == null)
                {
                    return NotFound();
                }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>CreateOrganization([FromBody] CreateOrganizationDto dto)    
        {
            var org=new Organization
            {
                Name=dto.Name,
                Description=dto.Description
            };
            var result=await _repository.CreateAsync(org);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateOrganization(int id,[FromBody] UpdateOrganizationDto dto)
        {

            var org=new Organization
            {
                Name=dto.Name,
                Description=dto.Description
            };
            var result=await _repository.UpdateAsync(id,org);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrganization(int id)
        {
            var result=await _repository.DeleteAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
   



        
    }

}