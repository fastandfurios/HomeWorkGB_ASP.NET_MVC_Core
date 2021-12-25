using ExampleWebApp.Data;
using ExampleWebApp.Models;
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
            _logger = logger;
            TestData.Departments.ToList().ForEach(d => { _employees = d.Employees; });
        }

        public IActionResult Departments()
        {
            return View(_departments);
        }

        public IActionResult Employees()
        {
            return View(_employees);
        }
    }
}
