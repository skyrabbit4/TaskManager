using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]

    public class TeamsController:ControllerBase
    {
    private readonly ITeamRepository _repository;
    public TeamsController(ITeamRepository repository)
    {
        _repository=repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var result=await _repository.GetTeamAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var result=await _repository.GetTeamByIdAsync(id);
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
        await _repository.CreateTeamAsync(team);
        return CreatedAtAction(nameof(GetTeamById),new{id=team.Id},team);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>UpdateTeams(int id ,[FromBody] UpdateTeamsDto dto)
        {
            var team =new Team
            {
                Name=dto.Name,
                Description=dto.Description
            };

           var result= await _repository.UpdateTeamAsync(id,team);
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

      [HttpDelete("{id}")]
public async Task<IActionResult> DeleteTeam(int id)
{
    try
    {
        var result = await _repository.DeleteTeamAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}







        

    }
}