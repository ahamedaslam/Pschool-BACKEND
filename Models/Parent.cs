namespace Pschool.API.Models
{
    public class Parent
    {
        public  int Id { get; set; }
        public  string FullName { get; set; } = string.Empty;
        public  string Email { get; set; }
        public  string Phone { get; set; }

        //one-to-many relationship
        public List<Student> Students { get; set; } = new();
    }
}
