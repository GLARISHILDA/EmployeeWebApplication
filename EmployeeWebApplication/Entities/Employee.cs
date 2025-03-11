namespace EmployeeWebApplication.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public DateTime StartingDate { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string? MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}