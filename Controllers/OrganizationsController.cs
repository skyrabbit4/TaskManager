using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrganizationsController(AppDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var organizations =await _context.Organizations.ToListAsync();
            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
           var result= await _context.Organizations.FindAsync(id);
            if (result == null)
                {
                    return NotFound();
                }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>CreateOrganization([FromBody] Organization organization)    
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateOrganization(int id,[FromBody] Organization organization)
        {
            var result=await _context.Organizations.FindAsync(id);
            if(result==null)
            {
                return NotFound();
            }
            result.Name=organization.Name;
            result.Description=organization.Description;
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