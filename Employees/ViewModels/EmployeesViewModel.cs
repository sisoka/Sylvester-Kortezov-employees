using Employees.Data;

namespace Employees.ViewModels
{
    public class EmployeesViewModel
    {
        public IList<Employee> Employees{ get; set; }

        public IList<Employee> EmployeePair { get; set; }
    }
}
