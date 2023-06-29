namespace MyCRM
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            MenuActionService menuService = new MenuActionService();
            menuService = MenuActionService.InitializeMenu(menuService);
            CompanyService companyService = new CompanyService();
            PersonService personService = new PersonService();
            ProjectService projectService = new ProjectService();
            do
            {
                Console.WriteLine("CRM. Wybierz opcję:");
                
                menuService.GetMenuByMenuName("main");
                Console.Write("=> ");
                var operation = Console.ReadKey();
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        menuService.GetMenuByMenuName("company");
                        companyService.CompanyServiceMenuAction();
                        break;
                    case '2':
                        Console.Clear();
                        menuService.GetMenuByMenuName("person");
                        personService.PersonServiceMenuAction(companyService);
                        break;
                    case '3':
                        Console.Clear();
                        menuService.GetMenuByMenuName("project");
                        projectService.ProjectServiceMenuAction();
                        break;
                    case '4':

                        break;
                    case '5':

                        break;
                    case '6':
                        exit = true;
                        Console.WriteLine("Program zakończył działanie.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
            } while (!exit);
        }
    }
}