
namespace Main
{
    internal class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// Provides options for managing employees, departments, and projects.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n============ Employee Management Application ============");
                Console.WriteLine("\n[1]Employee Management\n\n[2]Departments Management\n\n[3]Projects Management");
                Console.WriteLine("----------------------");
                Console.Write("Enter Your Choice : ");
                var ManagementChoice = int.Parse(Console.ReadLine());
                if (ManagementChoice == 1)
                {
                    Console.WriteLine("\n============ Employees Management ============");
                    Console.WriteLine("\n[1]Add New Employee.\n\n[2]Search For Employee.\n\n[3]Delete Employee\n\n[4]Print All Employees");
                    Console.WriteLine("----------------------");
                    Console.Write("Enter Your Choice : ");
                    var EmployeeManagementChoice = int.Parse(Console.ReadLine());
                    if (EmployeeManagementChoice == 1)
                    {
                        EmployeeManagement.AddNewEmployee();
                    }
                    else if (EmployeeManagementChoice == 2)
                    {
                        Console.Write("Enter Employee's ID : ");
                        var ID = int.Parse(Console.ReadLine());
                        Employee e =  EmployeeManagement.SearchForEmployee(ID);
                        Helper.PrintEmployee(e);
                    }
                    else if (EmployeeManagementChoice == 3)
                    {
                        Console.Write("Enter Employee's ID : ");
                        var ID = int.Parse(Console.ReadLine());
                        EmployeeManagement.DeleteEmployee(ID);
                    }
                    else if(EmployeeManagementChoice == 4)
                    {
                        EmployeeManagement.PrintAllEmployee();
                    }
                    else
                    {
                        throw new Exception($"{EmployeeManagementChoice} IS Not a Vaild Choice !!");
                    }
                }
                else if (ManagementChoice == 2)
                {
                    Console.WriteLine("============ Departments Management ============");
                    Console.WriteLine("\n[1]Add New Department.\n\n[2]Print All The Employees In Department.\n\n[3]Print All Departmnets.");
                    Console.WriteLine("----------------------");
                    Console.Write("Enter Your Choice : ");
                    var DepartmentsManagementChoice = int.Parse(Console.ReadLine());
                    if (DepartmentsManagementChoice == 1)
                    {
                        DepartmentManagement.AddDepartment();
                    }
                    else if (DepartmentsManagementChoice == 2)
                    {
                        Console.Write("Enter Deaprtmnet Name : ");
                        string name = Console.ReadLine();
                        DepartmentManagement.PrintAllEmployeesInDepartment(name);
                    }
                    else if (DepartmentsManagementChoice == 3)
                    {
                         DepartmentManagement.PrintAllDepartments();
                    }
                    else
                    {
                        throw new Exception($"{DepartmentsManagementChoice} IS Not a Vaild Choice !!");
                    }
                }
                else if (ManagementChoice == 3)
                {
                    Console.WriteLine("============ Projects Management ============");
                    Console.WriteLine("\n[1]Add New Project.\n\n[2]Increase Budget For Project.\n\n[3]Search For Project.");
                    Console.WriteLine("----------------------");
                    Console.Write("Enter Your Choice : ");
                    var ProjectsManagementChoice = int.Parse(Console.ReadLine());
                    if (ProjectsManagementChoice == 1)
                    {
                        ProjectManagement.AddNewProject();
                    }
                    else if(ProjectsManagementChoice == 2)
                    {
                        Console.Write("Enter Project Title : ");
                        string Title = Console.ReadLine();
                        Console.Write("Enter The Addition In Budget : ");
                        double Budget = double.Parse(Console.ReadLine());
                        ProjectManagement.IncreaseBudgetForProject(Title , Budget);
                    }
                    else if(ProjectsManagementChoice == 3)
                    {
                        Console.Write("Enter Project Title : ");
                        string Title = Console.ReadLine();
                        Project project = ProjectManagement.SearchForProject(Title);
                        Console.WriteLine($"\nProject Title : {project.Title}\nProject Manager {project.Manager.Name}\n Project Budget {project.Budget}");
                    }
                    else
                    {
                        throw new Exception($"{ProjectsManagementChoice} IS Not a Vaild Choice !!");
                    }
                }
                else
                {
                    throw new Exception($"{ManagementChoice} IS Not a Vaild Choice !!");
                }
            }




        }
    }
}
