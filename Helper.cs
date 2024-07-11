
using System.Collections.Generic;

namespace Main
{
    public class Helper
    {

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Prints the details of a given employee.
        /// </summary>
        /// <param name="employee">The employee whose details are to be printed.</param>
        public static void PrintEmployee(Employee employee)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Name : {employee.Name}\nID : {employee.ID}\nDepartment : {(employee.department.Name).ToUpper()}\nPhone : {employee.Phone}\nEmail : {employee.Email}");
            if (employee.Type == EmployeeType.salariedemployee)
            {
                Console.WriteLine($"Type : Salaried Employee\nBasic Salary : {(employee.Salary).ToString("F3")}");
            }
            else if (employee.Type == EmployeeType.hourlyemployee)
            {
                Console.WriteLine($"Type : Hourly Employee\nDues: {employee.Salary}");
            }
            else if (employee.Type == EmployeeType.commissionemployee)
            {
                Console.WriteLine($"Type : Commission Employee\nDues : {employee.Salary}");
            }
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Generates a unique ID for a new employee by ensuring it does not exist in the current list of employees.
        /// </summary>
        /// <param name="employees">The list of current employees.</param>
        /// <returns>A unique ID for a new employee.</returns>
        public static int HelperCreateID(List<Employee> employees)
        {
            Random rnd = new Random();
            int id;

            while (true)
            {
                id = rnd.Next();
                bool idExists = false;

                foreach (Employee emp in employees)
                {
                    if (emp.ID == id)
                    {
                        idExists = true;
                        break;
                    }
                }

                if (!idExists)
                {
                    break; 
                }
            }

            return id;
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Checks if a department with the given name exists in the list of departments.
        /// </summary>
        /// <param name="departments">The list of departments.</param>
        /// <param name="DepartmentName">The name of the department to check.</param>
        /// <returns>True if the department exists, otherwise false.</returns>
        public static bool DepartmentExist(List<Department> departments ,string DepartmentName)
        {
            bool Exist = false;
            foreach (Department department in departments)
            {
                if(department.Name == DepartmentName)
                {
                    Exist = true;
                    break;
                }
            }
            return Exist;
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Calculates the total salary and number of employees in a given department.
        /// </summary>
        /// <param name="DepartmentName">The name of the department.</param>
        /// <returns>An array where the first element is the total salary and the second element is the number of employees.</returns>
        public static double[] GetTotalSalaryAndNumberOfEmployeesInDeaprtment(string DepartmentName)
        {
            double totalSalary = 0;
            double totalEmployees = 0;
            foreach(Employee employee in EmployeeManagement.employees)
            {
                if(employee.department.Name == DepartmentName)
                {
                    totalSalary += employee.Salary;
                    totalEmployees++;
                }
            }
            return new double[] { totalSalary, totalEmployees };
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Checks if a project with the given title exists in the list of projects.
        /// </summary>
        /// <param name="ProjectTitle">The title of the project to check.</param>
        /// <returns>True if the project exists, otherwise false.</returns>
        public static bool ProjectExist(string ProjectTitle)
        {
            bool Exist = false;
            foreach(Project project in ProjectManagement.ProjectsList)
            {
                if(project.Title == ProjectTitle)
                {
                    Exist = true;
                    return true;
                }
            }
            return Exist;
        }
        /*--------------------------------------------------------------------------------------------*/
    }
}
