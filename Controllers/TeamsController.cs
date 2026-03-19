using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]

    public class TeamsController:ControllerBase
    {
    private readonly AppDbContext _context;
    public TeamsController(AppDbContext context)
    {
        _context=context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var result=await _context.Teams.Include(t=>t.Organization).ToListAsync();
        return Ok(result);
    }







        

    }
}