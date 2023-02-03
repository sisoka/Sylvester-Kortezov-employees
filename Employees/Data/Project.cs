namespace Employees.Data
{
    public class Project
    {
        public int ProjectID { get; set; }

        public int EmpID { get; set; }
        public IList<Employee> Employees { get; set; }


    }
}
