using ExampleWebApp.Data;
using ExampleWebApp.Models;
using ExampleWebApp.Services.Interfaces;
using ExampleWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ICollection<Department> _departments;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IEmployeeService _employeeService;

        public DepartmentController(ILogger<DepartmentController> logger, IEmployeeService employeeService)
        {
            _departments = TestData.Departments;
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Departments()
        {
            return View(_departments);
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
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
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction("Employees");
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeService.GetById(id);

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

        public IActionResult DetailsEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
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

            var employee = new Employee
            {
                Id = model.Id,
                Address = model.Address,
                LastName = model.LastName,
                Name = model.Name,
                Salary = model.Salary
            };
            
            _employeeService.Update(employee);

            return RedirectToAction(nameof(Employees));
        }

        public IActionResult Employees()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }
    }
}
