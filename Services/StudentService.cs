using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Helper;
using Pschool.API.Models;
using Pschool.API.Repositories;

namespace Pschool.API.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Response> GetAllAsync(string logId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(logId))
                {
                    _logger.LogWarning("Invalid logId received while retrieving all students.");
                    return ResponseHelper.NotFound("Log ID cannot be null or empty.");
                }

                var result = await _repo.GetAllStudentsAsync();

                if (result == null || !result.Any())
                {
                    _logger.LogInformation("No students found. LogId: {logId}", logId);
                    return ResponseHelper.NotFound("No student records found.");
                }

                _logger.LogInformation("Students retrieved successfully. LogId: {logId}", logId);
                return ResponseHelper.Success(result, "Students retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An error occurred while retrieving students.");
            }
        }

        public async Task<Response> GetByParentAsync(ParentidDTO request, string logId)
        {
            try
            {
                if (request == null || request.Id <= 0)
                    return ResponseHelper.NotFound("Invalid parent ID.");

                var students = await _repo.GetStudentByParentIdAsync(request);
                if (students == null || !students.Any())
                    return ResponseHelper.NotFound("No students found for the specified parent.");

                _logger.LogInformation("Students retrieved for parent {ParentId}. LogId: {logId}", request.Id, logId);
                return ResponseHelper.Success(students, "Students retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students by parent. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An error occurred while retrieving students by parent.");
            }
        }

        public async Task<Response> GetByIdAsync(StudentsIdDTO request, string logId)
        {
            try
            {
                if (request == null || request.Id <= 0)
                    return ResponseHelper.NotFound("Invalid student ID.");

                var student = await _repo.GetStudentsByIdAsync(request);
                if (student == null)
                    return ResponseHelper.NotFound("Student not found.");

                _logger.LogInformation("Student {StudentId} retrieved successfully. LogId: {logId}", request.Id, logId);
                return ResponseHelper.Success(student, "Student retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student by ID. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An error occurred while retrieving the student.");
            }
        }

        public async Task<Response> AddAsync(AddStudentDTO student, string logId)
        {
            try
            {
                if (student == null)
                    return ResponseHelper.NotFound("Student data cannot be null.");

                if (string.IsNullOrWhiteSpace(student.FullName))
                    return ResponseHelper.NotFound("Full name is required.");

                if (student.ParentId == 0)
                    return ResponseHelper.NotFound("ParentId is required.");

                var added = await _repo.AddStudentAsync(student);
                _logger.LogInformation("Student {Name} added successfully. LogId: {logId}", student.FullName, logId);

                return ResponseHelper.Success(added, "Student added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding student. LogId: {logId}", logId);
                return ResponseHelper.ServerError();
            }
        }

        public async Task<Response> UpdateAsync(StudentsDTO student, string logId)
        {
            try
            {
                if (student == null || student.Id <= 0)
                    return ResponseHelper.NotFound("Invalid student data.");

                if (string.IsNullOrWhiteSpace(student.FullName))
                    return ResponseHelper.NotFound("Full name is required.");

                var updated = await _repo.UpdateStudentAsync(student);
                if (updated == null)
                {
                    _logger.LogInformation("Student not found for update. ID: {StudentId}, LogId: {logId}", student.Id, logId);
                    return ResponseHelper.NotFound("Student not found.");
                }

                _logger.LogInformation("Student {Id} updated successfully. LogId: {logId}", student.Id, logId);
                return ResponseHelper.Success(updated, "Student updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An error occurred while updating the student.");
            }
        }

        public async Task<Response> DeleteAsync(int id, string logId)
        {
            try
            {
                if (id <= 0)
                    return ResponseHelper.NotFound("Invalid student ID.");

                var deleted = await _repo.DeleteStudentAsync(id);
                if (!deleted)
                {
                    _logger.LogInformation("Student not found for deletion. ID: {StudentId}, LogId: {logId}", id, logId);
                    return ResponseHelper.NotFound("Student not found.");
                }

                _logger.LogInformation("Student {Id} deleted successfully. LogId: {logId}", id, logId);
                return ResponseHelper.Success(null, "Student deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student. LogId: {logId}", logId);
                return ResponseHelper.ServerError("An error occurred while deleting the student.");
            }
        }
    }
}
