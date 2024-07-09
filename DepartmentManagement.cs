
namespace Main
{
    public class DepartmentManagement
    {
        /// <summary>
        /// List of all departments in the system.
        /// </summary>
        public static List<Department> departmentList = new List<Department>();
        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds a new department to the system by collecting the department name from the user.
        /// Throws an exception if the department already exists.
        /// </summary>
        /// <exception cref="Exception">Thrown when the department name already exists.</exception>
        public static void AddDepartment()
        {
            bool flag = false;
            Console.Write("Enter Department Name : ");
            string DepartmentName = Console.ReadLine();
            flag = Helper.DepartmentExist(departmentList, DepartmentName.ToLower());
            if(flag)
            {
                throw new Exception($"Department Name {DepartmentName} Already Exist");
            }
            Department department = new Department
            {
                Name = DepartmentName.ToLower() 
            };
            Console.WriteLine("----------------------");
            Console.WriteLine($"Department {(department.Name).ToUpper()} Is Added Successfully");
            departmentList.Add(department);
        }
        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Prints all employees in a specified department and calculates the total salary.
        /// </summary>
        /// <param name="DepartmentName">The name of the department.</param>
        public static void PrintAllEmployeesInDepartment(string DepartmentName)
        {
            double TotalSalary = 0;
            int TotalEmbloyess = 0;

            Console.WriteLine($"\nDepartment : {DepartmentName}");
            Console.WriteLine("-------------------------------------------");
            foreach (Employee emp in EmployeeManagement.employees)
            {
                if(emp.department.Name == DepartmentName)
                {
                    Helper.PrintEmployee(emp);
                    TotalSalary += emp.Salary;
                    TotalEmbloyess++;
                }
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"---> Number Of Empolyees In {DepartmentName} Department : {TotalEmbloyess}");
            Console.WriteLine($"---> Total Salary In {DepartmentName} Department : {TotalSalary}");
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Prints all departments along with the number of employees and total salary for each department.
        /// </summary>

        public static void PrintAllDepartments()
        {
            double totalSalary;
            int totalEmployees;

            foreach (var department in DepartmentManagement.departmentList)
            {
                totalSalary = 0;
                totalEmployees = 0;

                foreach (var employee in EmployeeManagement.employees)
                {
                    if (department.Name == employee.department.Name)
                    {
                        totalEmployees++;
                        totalSalary += employee.Salary;
                    }
                }

                Console.WriteLine($"\nDepartment : {department.Name}");
                Console.WriteLine("-------------------------------------------");
                department.TotalSalary = totalSalary;
                department.EmployeesNumber = totalEmployees;
                Console.WriteLine($"---> Number Of Employees In {department.Name} Department : {department.EmployeesNumber}");
                Console.WriteLine($"---> Total Salary In {department.Name} Department : {department.TotalSalary}");
            }
        }
    }   
}
