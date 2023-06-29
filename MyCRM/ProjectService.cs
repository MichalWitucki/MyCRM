using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public class ProjectService
    {
        public List<Project> Projects { get; set; }
        public ProjectService()
        {
            Projects = new List<Project>();
            Projects.Add(new Project() { Id = 1, City = "aa", VoivodeshipId = 12, Street = "a" });

        }
        public void ProjectServiceMenuAction()
        {
            bool exit = false;
            do
            {
                Console.Write("=> ");
                var operation = Console.ReadKey();
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        //AddNewProject();
                        break;
                    case '2':
                        //EditProject();
                        break;
                    case '3':
                        //RemoveProject();
                        break;
                    case '4':
                        //ShowProjectList();
                        break;
                    case '5':
                        exit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }

            } while (!exit);

        }
    }
}
