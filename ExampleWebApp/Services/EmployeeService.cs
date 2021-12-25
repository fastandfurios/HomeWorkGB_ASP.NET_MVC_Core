using ExampleWebApp.Data;
using ExampleWebApp.Models;
using ExampleWebApp.Services.Interfaces;

namespace ExampleWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private int _lastFreeId;
        private ICollection<Employee> _employees;

        public EmployeeService(ILogger<EmployeeService> logger)
        {
            _logger = logger;
            TestData.Departments.ToList().ForEach(d => { _employees = d.Employees; });

            _lastFreeId = _employees!.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
        }

        public int Add(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (_employees.Contains(employee))
                return employee.Id;

            employee.Id = _lastFreeId++;

            _employees.Add(employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var db_employee = GetById(id);

            if (db_employee is null)
                return false;

            _employees.Remove(db_employee);

            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return employee!;
        }

        public bool Update(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (_employees.Contains(employee))
                return true;

            var db_employee = GetById(employee.Id);

            if (db_employee is null)
                return false;

            db_employee.Address = employee.Address;
            db_employee.Name = employee.Name;
            db_employee.LastName = employee.LastName;
            db_employee.Salary = employee.Salary;

            return true;
        }
    }
}
