using ExampleWebApp.Models;

namespace ExampleWebApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        int Add(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Update(Employee employee);
    }
}
