using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public class MenuActionService
    {
        private List<MenuAction> _menu;

        public MenuActionService()
        {
            _menu = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menu = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            _menu.Add(menu);
        }

        public void GetMenuByMenuName(string menuName)
        {
            List<MenuAction> menuList = new List<MenuAction>();
            foreach (MenuAction menu in _menu)
                if (menu.MenuName == menuName)
                    menuList.Add(menu);
            foreach (MenuAction item in menuList)
                Console.WriteLine($"{item.Id}. {item.Name}.");

        }

        public static MenuActionService InitializeMenu(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction(1, "FIRMY", "main");
            menuActionService.AddNewAction(2, "OSOBY", "main");
            menuActionService.AddNewAction(3, "PROJEKTY", "main");
            menuActionService.AddNewAction(4, "KALENDARZ", "main");
            menuActionService.AddNewAction(5, "RAPORTY", "main");
            menuActionService.AddNewAction(6, "WYJDŹ Z PROGRAMU", "main");

            menuActionService.AddNewAction(1, "DODAJ NOWĄ FIRMĘ", "company");
            menuActionService.AddNewAction(2, "EDYTUJ FIRMĘ", "company");
            menuActionService.AddNewAction(3, "USUŃ FIRMĘ", "company");
            menuActionService.AddNewAction(4, "LISTA FIRM", "company");
            menuActionService.AddNewAction(5, "POWRÓT DO GŁÓWNEGO MENU", "company");

            menuActionService.AddNewAction(1, "DODAJ NOWĄ OSOBĘ", "person");
            menuActionService.AddNewAction(2, "EDYTUJ OSOBĘ", "person");
            menuActionService.AddNewAction(3, "USUŃ OSOBĘ", "person");
            menuActionService.AddNewAction(4, "LISTA OSÓB", "person");
            menuActionService.AddNewAction(5, "POWRÓT DO GŁÓWNEGO MENU", "person");

            menuActionService.AddNewAction(1, "DODAJ NOWY PROJEKT", "project");
            menuActionService.AddNewAction(2, "EDYTUJ PROJEKT", "project");
            menuActionService.AddNewAction(3, "USUŃ PROJEKT", "project");
            menuActionService.AddNewAction(4, "LISTA PROJEKTÓW", "project");
            menuActionService.AddNewAction(5, "POWRÓT DO GŁÓWNEGO MENU", "project");

            return menuActionService;
        }

    }
}
