using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Models;
using Pschool.API.Repositories;

namespace Pschool.API.Services
{
    public class ParentService
    {
        private readonly IParentRepository _repo;

        public ParentService(IParentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response> GetAllParentsAsync()
        {
            try
            {
                var parents = await _repo.GetAllAsync();
                return new Response
                {
                    ResponseCode = "101",
                    ResponseDescription = "Parents retrieved successfully",
                    ResponseObject = parents
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = "102",
                    ResponseDescription = $"Failed to retrieve parents: {ex.Message}",
                    ResponseObject = null
                };
            }
        }

        public async Task<Response> GetParentByIdAsync(ParentidDTO parentid)
        {
            try
            {
                var parent = await _repo.GetParentByIdAsync(parentid);
                if (parent == null)
                {
                    return new Response
                    {
                        ResponseCode = "103",
                        ResponseDescription = "Parent not found",
                        ResponseObject = null
                    };
                }
                return new Response
                {
                    ResponseCode = "101",
                    ResponseDescription = $"Parent retrieved successfully by Id: {parentid.Id}",
                    ResponseObject = parent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = "102",
                    ResponseDescription = $"Failed to retrieve parent: {ex.Message}",
                    ResponseObject = null
                };
            }
        }

        public async Task<Response> AddParentAsync(ParentsDTO parent)
        {
            try
            {
                var addedParent = await _repo.AddParentAsync(parent);
                return new Response
                {
                    ResponseCode = "101",
                    ResponseDescription = "Parent added successfully",
                    ResponseObject = addedParent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = "102",
                    ResponseDescription = $"Failed to add parent: {ex.Message}",
                    ResponseObject = null
                };
            }

        }

        public async Task<Response> UpdateParentAsync(UpdateParentDTO parent)
        {
            try
            {
                var updatedParent = await _repo.UpdateParentAsync(parent);
                if (updatedParent == null)
                {
                    return new Response
                    {
                        ResponseCode = "103",
                        ResponseDescription = "Parent not found for update",
                        ResponseObject = null
                    };
                }
                return new Response
                {
                    ResponseCode = "101",
                    ResponseDescription = "Parent updated successfully",
                    ResponseObject = updatedParent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = "102",
                    ResponseDescription = $"Failed to update parent: {ex.Message}",
                    ResponseObject = null
                };
            }
        }

        public async Task<Response> DeleteParentAsync(ParentidDTO id)
        {
            try
            {
                var isDeleted = await _repo.DeleteParentAsync(id);
                if (!isDeleted)
                {
                    return new Response
                    {
                        ResponseCode = "103",
                        ResponseDescription = "Parent not found for deletion",
                        ResponseObject = null
                    };
                }
                return new Response
                {
                    ResponseCode = "101",
                    ResponseDescription = "Parent deleted successfully",
                    ResponseObject = null
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = "102",
                    ResponseDescription = $"Failed to delete parent: {ex.Message}",
                    ResponseObject = null
                };
            }
        }
    }
}
