using ExampleWebApp.Data;
using ExampleWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICollection<Department> _departments;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
            _departments = TestData.Departments;
        }

        public IActionResult Index()
        {
            return View(_departments);
        }
    }
}
