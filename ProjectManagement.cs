
namespace Main
{
    public class ProjectManagement
    {
        /// <summary>
        /// List of all projects in the system.
        /// </summary>
        public static List<Project> ProjectsList = new List<Project>();
        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds a new project to the system by collecting necessary information from the user.
        /// Throws an exception if a project with the same title already exists.
        /// </summary>
        /// <exception cref="Exception">Thrown when a project with the same title already exists.</exception>
        public static void AddNewProject() 
        {
            Console.Write("Enter Project Title : ");
            string Title = Console.ReadLine();
            bool Exist = Helper.ProjectExist(Title);
            if(Exist)
            {
                throw new Exception("Project With The Same Title Already Exist !!");
            }
            Console.Write("Enter Id Of Project Manger : ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = EmployeeManagement.SearchForEmployee(id);
            Console.Write("Set A Initial Budget For The Project : ");
            double budget = Double.Parse(Console.ReadLine());
            Project project = new Project
            {
                Title = Title,
                Manager = employee,
                Budget = budget
            };
            ProjectsList.Add(project);
        }

        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Increases the budget for a specified project by a given amount.
        /// </summary>
        /// <param name="ProjectTitle">The title of the project.</param>
        /// <param name="NewBudget">The amount to increase the budget by.</param>
        public static void IncreaseBudgetForProject(string ProjectTitle , double NewBudget)
        {
            foreach(Project project in ProjectsList)
            {
                if(project.Title == ProjectTitle)
                {
                    project.Budget += NewBudget;
                    break;
                }
            }
        }
        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Searches for a project in the system by its title.
        /// </summary>
        /// <param name="ProjectTitle">The title of the project to search for.</param>
        /// <returns>The project with the specified title, or null if not found.</returns>
        public static Project SearchForProject(string ProjectTitle)
        {
            Project project1 = null;
            foreach (Project project in ProjectsList)
            {
                if (project.Title == ProjectTitle)
                {
                    project1 = project;
                }
            }
            return project1;
        }
        /*--------------------------------------------------------------------------------------------*/
    }
}
