using ExampleWebApp.Models;

namespace ExampleWebApp.Data
{
    public class TestData
    {
        public ICollection<Department> Departments { get; } = Enumerable.Range(1, 20)
            .Select(i => new Department
            {
                Id = i,
                Employees = new List<Employee>
                {
                    new()
                    {
                        Id = i,
                        Address = $"Адрес-{i}",
                        LastName = $"Фамилия-{i}",
                        Name = $"Имя-{i}",
                        Salary = i,
                    }
                },
                PhoneNumber = $"Телефон-{i}"
            })
            .ToList();
    }
}
