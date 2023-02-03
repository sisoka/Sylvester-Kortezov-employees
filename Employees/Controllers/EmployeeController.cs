using Employees.Data;
using Employees.Services;
using Employees.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        private IList<Employee> listOfEmployees;
        private readonly IEmployeeService? _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            listOfEmployees = new List<Employee>();
        }
        public IActionResult GetAllEmployees(EmployeesViewModel employeesViewModel)
        {
            var listOfEmpl = _employeeService?.GetEmplFromCSV(@"C:\Users\sisko\source\repos\Employees\Employees\wwwroot\DataFile\employees.csv");
            if (listOfEmpl != null)
            {
                employeesViewModel.Employees = listOfEmpl;
                listOfEmployees = listOfEmpl;
            }
            return View(employeesViewModel);
        }

        public IActionResult GetEmployeePair(EmployeesViewModel employeesViewModel)
        {
            var pair = _employeeService?.FindLongestWorkingPair(listOfEmployees);
            return View(employeesViewModel);
        }

    }
}
