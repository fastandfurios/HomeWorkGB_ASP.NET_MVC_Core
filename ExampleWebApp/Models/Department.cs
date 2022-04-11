namespace ExampleWebApp.Models
{
    public class Department
    {
        public ICollection<Employee> Employees { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
