using ExampleWebApp.Models;

namespace ExampleWebApp.Data
{
    public class TestData
    {
        public static ICollection<Department> Departments { get; } = Enumerable.Range(1, 20)
            .Select(i => new Department
            {
                Id = i,
                Name = $"Отдел-{i}",
                Employees = Enumerable.Range(1, 5)
                    .Select(j => new Employee
                    {
                        Id = j,
                        Address = $"Адрес-{j}",
                        LastName = $"Фамилия-{j}",
                        Name = $"Имя-{j}",
                        Salary = j * 10000,
                    })
                    .ToList(),
                PhoneNumber = $"Телефон-{i}"
            })
            .ToList();
    }
}
