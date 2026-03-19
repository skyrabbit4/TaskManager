using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var result=await _context.Teams.Include(t=>t.Organization).FirstOrDefaultAsync(t=>t.Id==id);
        if(result==null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeams([FromBody] CreateTeamDto dto)
    {
        var team=new Team
        {
            Name=dto.Name,
            Description=dto.Description,
            OrganizationId=dto.OrganizationId
        };
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTeamById),new{id=team.Id},team);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>UpdateTeams(int id ,[FromBody] UpdateTeamsDto dto)
        {
            var result=await _context.Teams.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result.Description=dto.Description;
            result.Name=dto.Name;
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
           var result=await _context.Teams.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _context.Teams.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();
        }







        

    }
}