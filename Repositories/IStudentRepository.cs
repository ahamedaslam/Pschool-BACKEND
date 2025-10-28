using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Models;

namespace Pschool.API.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentsDTO>> GetAllStudentsAsync();
        Task<IEnumerable<Student?>> GetStudentsByIdAsync(StudentsIdDTO id);
        Task<Student> AddStudentAsync(AddStudentDTO student);
        Task<Student> UpdateStudentAsync(StudentsDTO updateStudentDTO);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student> GetStudentByParentIdAsync(ParentidDTO parentid);
    }
}
