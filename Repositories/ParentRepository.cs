using Microsoft.EntityFrameworkCore;
using Pschool.API.Data;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Models;

namespace Pschool.API.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly AppDBContext _context;
        public ParentRepository(AppDBContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return await _context.Parents.Include(p => p.Students).ToListAsync();
        }

        public async Task<Parent?> GetParentByIdAsync(ParentidDTO parentId)
        {
            //Eager loading of related Students
            return await _context.Parents.Include(p => p.Students)
                                        .FirstOrDefaultAsync(p => p.Id == parentId.Id);
        }

        public async Task<Parent> AddParentAsync(ParentsDTO parentDto)
        {
            var parent = new Parent
            {
                FullName = parentDto.FullName,
                Email = parentDto.Email,
                Phone = parentDto.Phone
            };
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
            return parent;
        }
        
        public async Task<Parent> UpdateParentAsync(UpdateParentDTO parentDto)
        {
            var existing = await _context.Parents.FindAsync(parentDto.Id);
            if (existing == null) return null;

            existing.FullName = parentDto.FullName;
            existing.Email = parentDto.Email;
            existing.Phone = parentDto.Phone;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteParentAsync(ParentidDTO id)
        {
            var parent = await _context.Parents.FindAsync(id.Id);
            if (parent == null) return false;

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return true;
        }

    
    }
}
