using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;

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


        
    }

}