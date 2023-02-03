using Employees.Data;
using System;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IList<Employee> GetEmplFromCSV(string filePath)
        {
            var employees = new List<Employee>();
            using (var reader = new StreamReader(filePath))
            {
                var lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    if (lineCounter > 0)
                    {
                        var data = reader.ReadLine()?.Split(",");
                        if (data?.Length > 0)
                        {
                            var empID = int.Parse(data[0]);
                            var projectID = int.Parse(data[1]);
                            var dateFrom = DateTime.Parse(data[2]);
                            var dateTo = data[3] == "NULL" ? DateTime.UtcNow : DateTime.Parse(data[3]);
                            var newEmployee = new Employee { 
                                EmpID = empID,
                                ProjectID = projectID, 
                                DateFrom = dateFrom, 
                                DateTo = dateTo 
                            };
                            employees.Add(newEmployee);
                        }
                    }
                    lineCounter++;
                }
            }
            return employees;
        }


        public EmployeePair FindLongestWorkingPair(IList<Employee> employees)
        {
            var employeePairs = new Dictionary<EmployeePair, int>();
            foreach (var firstEmp in employees)
            {
                foreach (var secondEmp in employees)
                {
                    if (firstEmp.EmpID == secondEmp.EmpID || firstEmp.ProjectID != secondEmp.ProjectID)
                    {
                        continue;
                    }
                    var start = MaxOf(firstEmp.DateFrom, secondEmp.DateFrom);
                    var end = MinOf((DateTime)firstEmp.DateTo, (DateTime)secondEmp.DateTo );
                    if (start < end)
                    {
                        var days = (end - start).Days + 1;
                        var key = new EmployeePair(firstEmp.EmpID, secondEmp.EmpID);
                        if (!employeePairs.ContainsKey(key) || employeePairs[key] < days)
                        {
                            employeePairs[key] = days;
                        }
                    }
                }
            }
            var longestPair = employeePairs.OrderByDescending(kvp => kvp.Value).First();
            return longestPair.Key;

        }

        private static DateTime MaxOf(DateTime firstEmpDate, DateTime secondEmpDate)
        {
            return firstEmpDate > secondEmpDate ? firstEmpDate : secondEmpDate;
        }

        private static DateTime MinOf(DateTime firstEmpDate, DateTime secondEmpDate)
        {
            return firstEmpDate < secondEmpDate ? firstEmpDate : secondEmpDate;
        }
    }
}
