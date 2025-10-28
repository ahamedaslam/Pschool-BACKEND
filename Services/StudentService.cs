using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Models;
using Pschool.API.Repositories;

namespace Pschool.API.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response> GetAllAsync()
        {
            var result = await _repo.GetAllStudentsAsync();
            return new Response
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                ResponseObject = result
            };
        }

        public async Task<Response> GetByParentAsync(ParentidDTO request)
        {
            var students = await _repo.GetStudentByParentIdAsync(request);
            return new Response
            {
                ResponseCode = "00",
                ResponseDescription = "Success",
                ResponseObject = students
            };
        }

        public async Task<Response> GetByIdAsync(StudentsIdDTO request)
        {
            var student = await _repo.GetStudentsByIdAsync(request);
            if (student == null)
                return new Response { ResponseCode = "01", ResponseDescription = "Student not found" };

            return new Response { ResponseCode = "00", ResponseDescription = "Success", ResponseObject = student };
        }

        public async Task<Response> AddAsync(AddStudentDTO student)
        {
            var added = await _repo.AddStudentAsync(student);
            return new Response { ResponseCode = "00", ResponseDescription = "Student added", ResponseObject = added };
        }

        public async Task<Response> UpdateAsync(StudentsDTO student)
        {
            var updated = await _repo.UpdateStudentAsync(student);
            if (updated == null)
                return new Response { ResponseCode = "01", ResponseDescription = "Student not found" };

            return new Response { ResponseCode = "00", ResponseDescription = "Student updated", ResponseObject = updated };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteStudentAsync(id);
            return new Response
            {
                ResponseCode = deleted ? "00" : "01",
                ResponseDescription = deleted ? "Student deleted" : "Student not found"
            };
        }
    }
}
