namespace MyCRM
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("CRM. Wybierz opcję:");
                MenuActionService menuService = new MenuActionService();
                menuService = MenuActionService.InitializeMenu(menuService);
                menuService.GetMenuByMenuName("main");
                var operation = Console.ReadKey();
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        menuService.GetMenuByMenuName("company");
                        operation = Console.ReadKey();
                        CompanyService companyService = new CompanyService();
                        companyService.CompanyServiceAction();
                        break;
                    case '2':
                        Console.Clear();
                        menuService.GetMenuByMenuName("person");
                        operation = Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        menuService.GetMenuByMenuName("project");
                        operation = Console.ReadKey();
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