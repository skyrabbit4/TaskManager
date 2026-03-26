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
        private readonly AppDbContext _context;
        private readonly IOrganizationRepository organization;
        public OrganizationsController(AppDbContext context, IOrganizationRepository organization)
        {
            _context=context;
            this.organization=organization;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var organizations =await organization.GetAllAsync();
            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
           var result= await organization.GetByIdAsync(id);
            if (result == null)
                {
                    return NotFound();
                }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>CreateOrganization([FromBody] CreateOrganizationDto dto)    
        {
            var result=await organization.CreateAsync(dto);
            
            return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateOrganization(int id,[FromBody] UpdateOrganizationDto dto)
        {
            var result=await organization.UpdateAsync(id);
            if(result==null)
            {
                return NotFound();
            }
            result.Name=dto.Name;
            result.Description=dto.Description;
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrganization(int id)
        {
            var result=await _context.Organizations.FindAsync(id);
            if(result==null)
            {
                return NotFound();
            }
             _context.Organizations.Remove(result);
             await _context.SaveChangesAsync();
            return NoContent();
        }
   



        
    }

}