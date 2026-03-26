
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

        public async Task<Organization?>UpdateAsync(int id, Organization organization)
        {
            var result= await _context.Organizations.FindAsync(id);

            if(result==null)
            {
                 return null;
            }
            result.Name=organization.Name;
            result.Description=organization.Description;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool>DeleteOrganization(int id)
        {
            var result = await _context.Organizations.FindAsync(id);
            if(result==null)
            {
                return false;
            }
            _context.Organizations.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }




    }

}

