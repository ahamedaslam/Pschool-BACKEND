using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Helper;
using Pschool.API.Models;
using Pschool.API.Repositories;

namespace Pschool.API.Services
{
    public class ParentService
    {
        private readonly IParentRepository _repo;
        private readonly ILogger<ParentService> _logger;

        public ParentService(IParentRepository repo, ILogger<ParentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Response> GetAllParentsAsync(string logId)
        {
            try
            {

                var parents = await _repo.GetAllAsync();

                if (parents == null || !parents.Any())
                {
                    _logger.LogInformation("No parent records found. LogId: {logId}", logId);
                    return ResponseHelper.NotFound("No parent records found.");
                }

                _logger.LogInformation("Parents retrieved successfully. LogId: {logId}", logId);
                return ResponseHelper.Success(parents, "Parents retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving parents. LogId: {logId}", logId);
                return ResponseHelper.ServerError();
            }
        }


        public async Task<Response> GetParentByIdAsync(ParentidDTO parentid,string logId)
        {
            try
            {
                var parent = await _repo.GetParentByIdAsync(parentid);
                if (parent == null)
                {
                   _logger.LogInformation("Parent not found with ID: {parentId}. LogId: {logId}", parentid.Id, logId);
                    return ResponseHelper.NotFound("Parent not found.");
                }
               return ResponseHelper.Success(parent, "Parent retrieved successfully.");
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "Error retrieving parent by ID. LogId: {logId}", logId);
                return ResponseHelper.ServerError();
            }
        }

        public async Task<Response> AddParentAsync(ParentsDTO parent, string logId)
        {
            try
            {
             
                if (parent == null)
                {
                    _logger.LogWarning("Parent DTO is null. LogId: {logId}", logId);
                    return ResponseHelper.NotFound("Parent data cannot be null.");
                }

                 var addedParent = await _repo.AddParentAsync(parent);
                _logger.LogInformation("Parent added successfully: {FullName}, LogId: {logId}", parent.FullName, logId);
                 return ResponseHelper.Success(addedParent, "Parent added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new parent. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An unexpected error occurred while adding the parent.");
            }
        }


        public async Task<Response> UpdateParentAsync(UpdateParentDTO parent,string logId)
        {
            try
            {
                var updatedParent = await _repo.UpdateParentAsync(parent);
                if (updatedParent == null)
                {
                    _logger.LogInformation("Parent not found with ID: {parentId}. LogId: {logId}", parent.Id, logId);
                    return ResponseHelper.NotFound("Parent not found");
                }
                _logger.LogInformation("Parent updated successfully: {FullName}, LogId: {logId}", parent.FullName, logId);
                return ResponseHelper.Success(updatedParent, "Parent updated successfully");
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "Error updating parent. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An unexpected error occurred while updating the parent.");
            }
        }

        public async Task<Response> DeleteParentAsync(ParentidDTO request)
        {
            try
            {
                var isDeleted = await _repo.DeleteParentAsync(request);
                if (!isDeleted)
                {
                    _logger.LogInformation("Parent not found or could not be deleted with ID: {parentId}.", request.Id);
                    return ResponseHelper.NotFound("Parent not found or could not be deleted.");
                }
                _logger.LogInformation("Parent deleted successfully with ID: {parentId}.", request.Id);
                return ResponseHelper.Success(isDeleted, "Parent deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting parent with ID: {parentId}.", request.Id);
                return ResponseHelper.ServerError("An unexpected error occurred while deleting the parent.");
            }
        }
    }
}
