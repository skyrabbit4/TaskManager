
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories
{
    public class OrganizationRepository:IOrganizationRepository
    {

        private readonly AppDbContext _context;
        
        public OrganizationRepository(AppDbContext dbContext)
        {
            _context=dbContext;
        }

        public async Task<List<Organization>>GetAllAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<Organization?>GetByIdAsync(int id)
        {
            return await _context.Organizations.FindAsync(id);
        }

        public async Task<Organization>CreateAsync(Organization organization)
        {
             var org=new Organization
            {
                Name=organization.Name,
                Description=organization.Description
            };
            await _context.Organizations.AddAsync(org);
            await _context.SaveChangesAsync();
            return org;
        }




    }

}

