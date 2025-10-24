namespace Pschool.API.DTOs.StudentDTO
{
    public class StudentsDTO
    {
      //  public int Id { get; set; }
        public string FullName { get; set; } = string.Empty; //avoids null and compiler warnings
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Siblings { get; set; }
        public int ParentId { get; set; }
    }
}
