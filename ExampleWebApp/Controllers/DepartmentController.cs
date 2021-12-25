using ExampleWebApp.Data;
using ExampleWebApp.Models;
using ExampleWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ICollection<Department> _departments;
        private ICollection<Employee> _employees;
        private readonly ILogger<DepartmentController> _logger;
        
        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _departments = TestData.Departments;
            _departments.ToList().ForEach(d => { _employees = d.Employees; });
            _logger = logger;
        }

        public IActionResult Departments()
        {
            return View(_departments);
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);

            if (employee is null)
                return NotFound();

            var model = new EmployeeViewModel
            {
                Id = employee.Id,
                Address = employee.Address,
                LastName = employee.LastName,
                Name = employee.Name,
                Salary = employee.Salary
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var employee = _employees.FirstOrDefault(e => e.Id == model.Id);
            if (employee is null)
                return NotFound();

            employee.Address = model.Address;
            employee.LastName = model.LastName;
            employee.Name = model.Name;
            employee.Salary = model.Salary;

            return RedirectToAction(nameof(Employees));
        }

        public IActionResult Employees()
        {
            return View(_employees);
        }
    }
}
