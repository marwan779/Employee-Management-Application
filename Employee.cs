
namespace Main
{
    public class Employee
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email {  get; set; }
        public double Salary { get; set; }
        public EmployeeType Type { get; set; }

        public Department department = new Department();
        public virtual double CalculateSalary() => 0;
    }

    public enum EmployeeType
    {
        salariedemployee,
        hourlyemployee,
        commissionemployee
    }


    public class Department
    {
        public double EmployeesNumber { get;  set; }
        public double TotalSalary { get; set; }
        public string Name { get; set; }
    }

    public class SalariedEmployee : Employee
    {
        public  double BaiscSalary { set; private get; }
        public void SetSalary(double _Basicsalary)
        {

            if (_Basicsalary < 4000)
            {
                throw new Exception("Salary Can't Be Less Than 4000");
            }
            else
            {
                BaiscSalary = _Basicsalary;
            }
        }
        public override double CalculateSalary()
        {
            
            return BaiscSalary;
        }
    }

    public class HourlyEmployee : Employee
    {
        public double Hours { get; set; }
        public double Rate { get; set; }
        public override double CalculateSalary() => (Hours*Rate);
    }

    public class CommissionEmployee : Employee
    {
        public int Target { get; set; }
        public override double CalculateSalary() => (0.05 * Target);
        
    }

}
