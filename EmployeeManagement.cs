
namespace Main
{
    public class EmployeeManagement
    {
        /// <summary>
        /// List of all employees in the system.
        /// </summary>
        public static List<Employee> employees = new List<Employee>();

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds a new employee to the system by collecting necessary information from the user.
        /// Throws exceptions if required information is not provided or is invalid.
        /// </summary>
        /// <exception cref="Exception">Thrown when input data is invalid or missing.</exception>
        public static void AddNewEmployee()
        {
            Employee employee = new Employee();
            
            Console.Write("Enter Employee Name : ");
            string employeename = Console.ReadLine();
            
            if (String.IsNullOrEmpty(employeename))
            {
                throw new Exception("You Must Enter Employee Name !!");
            }
            employee.Name = employeename;

            Console.Write("Enter Employee Department : ");
            string departmentname = Console.ReadLine();
            if (String.IsNullOrEmpty(departmentname))
            {
                throw new Exception("You Must Enter Employee Department !!");
            }
            else if(!(Helper.DepartmentExist(DepartmentManagement.departmentList , departmentname)))
            {
                throw new Exception($"Department {departmentname} Not Found !!");
            }
            employee.department.Name = departmentname;

            Console.Write("Enter Employee Phone : ");
            string phone = Console.ReadLine();
            if (phone.Length < 11)
            {
                throw new Exception($"Phone NUmber Must Equal 11 Digit You Enterd {phone}");
            }
            employee.Phone = phone;

            Console.Write("Enter Employee Email : ");
            string email = Console.ReadLine();
            if(!email.Contains("@gmail.com"))
            {
                throw new Exception($"{email} Not In a Vaild Format ");
            }
            employee.Email =email;

            Console.Write("\n[1]Salaried Employee\n[2]Hourly Employee\n[3]Commission Employee\nEnter Employee Type : ");
            int employeetype = int.Parse(Console.ReadLine());

            if(employeetype == 1)
            {
                SalariedEmployee Salariedemployee = new SalariedEmployee ();
                employee.Type = EmployeeType.salariedemployee;
                Console.Write("Enter Employee Basic Salary: ");
                double TempSalary =  double.Parse(Console.ReadLine());
                Salariedemployee.SetSalary(TempSalary);
                employee.Salary = Salariedemployee.CalculateSalary();
            }
            else if(employeetype == 2)
            {
                HourlyEmployee Hourlyemployee = new HourlyEmployee();
                employee.Type = EmployeeType.hourlyemployee;
                Console.Write("Enter Employee Worked Hours: ");
                Hourlyemployee.Hours = double.Parse(Console.ReadLine());
                Console.Write("Enter Employee Rate : ");
                Hourlyemployee.Rate = double.Parse(Console.ReadLine());
                employee.Salary = Hourlyemployee.CalculateSalary();

            }
            else if (employeetype == 3)
            {
                CommissionEmployee Commissionemployee = new CommissionEmployee();
                employee.Type = EmployeeType.commissionemployee;
                Console.Write("Enter Target : ");
                Commissionemployee.Target = int.Parse(Console.ReadLine());
                employee.Salary = Commissionemployee.CalculateSalary();
            }
            else
            {
                throw new Exception($"{employeetype} Is Not A Valid Type!!");
            }

            int id = Helper.HelperCreateID(employees);
            employee.ID = id;
            employees.Add( employee );
            Console.WriteLine("Employee Added Successfully.");
            Helper.PrintEmployee(employee);
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Searches for an employee in the system by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to search for.</param>
        /// <returns>The employee with the specified ID.</returns>
        /// <exception cref="Exception">Thrown when the employee is not found.</exception>
        public static Employee SearchForEmployee(int id)
        {
            int Index = -1;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ID == id)
                {
                    Index = i; 
                    break;   
                }
            }
            if (Index == -1)
            {
                throw new Exception($"Employee With Id : {id} Not Found In The System !!");
            }
            else
            {
                return employees[Index];
            }
        }

        /*--------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// Deletes an employee from the system by their ID.
        /// Asks for confirmation before deletion.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <exception cref="Exception">Thrown when an invalid choice is made during confirmation.</exception>
        public static void DeleteEmployee(int id)
        {
            Employee employee = SearchForEmployee(id);
            Helper.PrintEmployee(employee);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Are You Sure You Want To Delete This Employee From The System [Yes]->(Y/y) [No]->(N/n)");
            char Choice = Console.ReadKey().KeyChar;
            Choice = Char.ToLower(Choice);
            if (Choice == 'y')
            {
                employees.Remove(employee);
            }
            else if (Choice == 'n')
            {
                Console.WriteLine("\nThe Deletion Is Cancelled");
            }
            else
            {
                throw new Exception($"{Choice} IS Not a Vaild Choice !!");
            }
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Prints all employees in the system.
        /// </summary>
        public static void PrintAllEmployee()
        {
            foreach (Employee employee in employees)
            {
                Helper.PrintEmployee(employee);
            }
        }
    }

}
