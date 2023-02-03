namespace Employees.Data
{
    public class EmployeePair
    {
        public EmployeePair(int firstEmpId, int secondEmpId)
        {
            FirstEmpId = firstEmpId;
            SecondEmpId = secondEmpId;
        }
        public int FirstEmpId { get; set; }
        public int SecondEmpId { get; set; }

        
    }
}
