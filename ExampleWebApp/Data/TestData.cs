using ExampleWebApp.Models;

namespace ExampleWebApp.Data
{
    public static class TestData
    {
        public static ICollection<Department> Departments { get; } = Enumerable.Range(1, 20)
            .Select(i => new Department
            {
                Id = i,
                Name = $"Отдел-{i}",
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
