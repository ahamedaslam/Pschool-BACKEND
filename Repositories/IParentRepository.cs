using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Models;

namespace Pschool.API.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent?> GetParentByIdAsync(ParentidDTO id);
        Task<Parent> AddParentAsync(AddParentDTO parent);
        Task<Parent> UpdateParentAsync(UpdateParentDTO parent);
        Task<bool> DeleteParentAsync(ParentidDTO id);
    }
}
