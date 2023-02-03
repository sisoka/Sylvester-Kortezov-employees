﻿namespace Employees.Data
{
    public class Employee
    {
        public int EmpID { get; set; }

        public int ProjectID { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo{ get; set; }

        public IList<Project> Projects{ get; set; }
    }
}
