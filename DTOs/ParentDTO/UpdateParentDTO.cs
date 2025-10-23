namespace Pschool.API.DTOs.ParentDTO
{
    public class UpdateParentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
