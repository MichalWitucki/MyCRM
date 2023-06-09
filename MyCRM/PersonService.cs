using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM
{
    public class PersonService
    {
        public void PersonServiceMenuAction(CompanyService companyService)
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
                        AddNewPerson(companyService);
                        break;
                    case '2':
                        //EditPerson();
                        break;
                    case '3':
                        //RemovePerson();
                        break;
                    case '4':
                        //ShowPersonList();
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
        private int getId()
        {
            var chosenId = Console.ReadLine();
            if (int.TryParse(chosenId, out int id))
                return id;
            else
                return 0;
        }
        private void AddNewPerson(CompanyService companyService)
        {
            Person person = new Person();
            Console.WriteLine("Dodawanie nowej osoby.");
            Console.Write("Podaj Id firmy, do której chcesz dodać osobę: ");
            var companyId = getId();
            var companyToAddPerson = companyService.Companies.FirstOrDefault(x => x.Id == companyId);
            if (companyToAddPerson != null)
            {
                Console.WriteLine("sss");
            }
            else
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }
    }
}
