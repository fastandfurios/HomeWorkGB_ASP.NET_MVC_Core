using ExampleWebApp.Data;
using ExampleWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICollection<Department> _departments;
        private ICollection<Employee> _employees;
        private readonly ILogger<CompanyController> _logger;
        

        public CompanyController(ILogger<CompanyController> logger)
        {
            _departments = TestData.Departments;
            TestData.Departments.ToList().ForEach(d => { _employees = d.Employees; });
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_departments);
        }

        public IActionResult Department()
        {
            return View(_employees);
        }
    }
}
