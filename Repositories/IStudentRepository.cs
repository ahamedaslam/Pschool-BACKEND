using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Models;

namespace Pschool.API.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student?>> GetStudentsByIdAsync(StudentsIdDTO id);
        Task<Student> AddStudentAsync(StudentsDTO student);
        Task<Student> UpdateStudentAsync(UpdStudentsDTO updateStudentDTO);
        Task<bool> DeleteStudentAsync(StudentsIdDTO id);
        Task<Student> GetStudentByParentIdAsync(ParentidDTO parentid);
    }
}
