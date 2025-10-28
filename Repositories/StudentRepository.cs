using Microsoft.EntityFrameworkCore;
using Pschool.API.Data;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Models;

namespace Pschool.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _context;

        public StudentRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudentAsync(AddStudentDTO student)
        {
            var students = new Student
            {
                FullName = student.FullName,
                Age = student.Age,
                Phone = student.Phone,
                Address = student.Address,
                Siblings = student.Siblings,
                ParentId = student.ParentId
            };
            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync();
            return students;

        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<StudentsDTO>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Select(s => new StudentsDTO
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Age = s.Age,
                    Phone = s.Phone,
                    Address = s.Address,
                    ParentId = s.ParentId,
                    //ParentName = s.Parent != null ? s.Parent.FullName : null
                })
                .ToListAsync();
        }


        public async Task<Student> GetStudentByParentIdAsync(ParentidDTO request)
        {
            var student =  await _context.Students.Include(s => s.Parent)
                                         .FirstOrDefaultAsync(s => s.ParentId == request.Id);
            return student;
        }

        public async Task<IEnumerable<Student?>> GetStudentsByIdAsync(StudentsIdDTO request)
        {
            return await _context.Students.Where(s => s.Id == request.Id).ToListAsync();
        }

        public async Task<Student> UpdateStudentAsync(StudentsDTO student)
        {
            var existing = await _context.Students.FindAsync(student.Id);
            if (existing == null) return null;



            _context.Entry(existing).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
