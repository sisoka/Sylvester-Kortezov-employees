using Employees.Data;

namespace Employees.Services
{
    public interface IEmployeeService
    {
        public IList<Employee> GetEmplFromCSV(string filePath);

        public EmployeePair FindLongestWorkingPair(IList<Employee> employees);
    }
}
