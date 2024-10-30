using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourNamespace.Data;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return View(employees);
        }
}
}
