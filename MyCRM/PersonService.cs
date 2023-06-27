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
                        EditPerson(companyService);
                        break;
                    case '3':
                        RemovePerson(companyService);
                        break;
                    case '4':
                        ShowPersonList(companyService);
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



        private void AddNewPerson(CompanyService companyService)
        {
            Console.WriteLine("Dodawanie nowej osoby.");
            Console.Write("Podaj Id firmy, do której chcesz dodać osobę: ");
            var companyId = Helpers.getId();
            var companyToAddPerson = companyService.Companies.FirstOrDefault(x => x.Id == companyId);
            if (companyToAddPerson != null)
            {
                Person person = new Person();
                Console.Write("Imię: ");
                person.FirstName = Console.ReadLine();
                Console.Write("Nazwisko: ");
                person.LastName = Console.ReadLine();
                Console.Write("Telefon: ");
                int.TryParse(Console.ReadLine(), out int phoneNumber);
                person.PhoneNumber = phoneNumber;
                Console.Write("E-Mail: ");
                person.Mail = Console.ReadLine();
                if (companyToAddPerson.Staff.Count == 0)
                    person.Id = 1;
                else
                    person.Id = companyToAddPerson.Staff.Last().Id + 1;

                companyToAddPerson.Staff.Add(person);
                Console.WriteLine($"Do firmy {companyToAddPerson.Name} dodano nową osobę {person.FirstName} {person.LastName} o Id {person.Id}.");

            }
            else
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }
        private void EditPerson(CompanyService companyService)
        {
            Console.WriteLine("Edycja osoby.");
            Console.Write("Podaj Id firmy, w której chcesz edytować osobę: ");
            var companyId = Helpers.getId();
            var companyToEditPerson = companyService.Companies.FirstOrDefault(x => x.Id == companyId);
            if (companyToEditPerson != null)
            {
                Console.Write("Podaj Id osoby, którą chcesz edytować: ");
                var personId = Helpers.getId();
                var personToEdit = companyToEditPerson.Staff.FirstOrDefault(x => x.Id == personId);
                if (personToEdit != null)
                {
                    Console.Write("Imię: ");
                    personToEdit.FirstName = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    personToEdit.LastName = Console.ReadLine();
                    Console.Write("Telefon: ");
                    int.TryParse(Console.ReadLine(), out int phoneNumber);
                    personToEdit.PhoneNumber = phoneNumber;
                    Console.Write("E-Mail: ");
                    personToEdit.Mail = Console.ReadLine();
                    Console.WriteLine($"W firmie {companyToEditPerson.Name} zaktualizowano dane osoby o Id {personToEdit.Id}: {personToEdit.FirstName} {personToEdit.LastName}");
                }
                else
                    Console.WriteLine("Nie znaleziono osoby o podanym Id.");
            }
            else
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }

        private void RemovePerson(CompanyService companyService)
        {
            Console.WriteLine("Usuwanie osoby.");
            Console.Write("Podaj Id firmy, w której chcesz usunąć osobę: ");
            var companyId = Helpers.getId();
            var companyToRemovePerson = companyService.Companies.FirstOrDefault(x => x.Id == companyId);
            if (companyToRemovePerson != null)
            {
                Console.Write("Podaj Id osoby, którą chcesz usunąć: ");
                var personId = Helpers.getId();
                var personToRemove = companyToRemovePerson.Staff.FirstOrDefault(x => x.Id == personId);
                if (personToRemove != null)
                {
                    companyToRemovePerson.Staff.Remove(personToRemove);
                    Console.WriteLine($"W firmie {companyToRemovePerson.Name} usunięto osobę o Id {personToRemove.Id}: {personToRemove.FirstName} {personToRemove.LastName}");
                }
                else
                    Console.WriteLine("Nie znaleziono osoby o podanym Id.");
            }
            else
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }
        private void ShowPersonList(CompanyService companyService)
        {
            Console.Write("Podaj Id firmy aby zobaczyć osoby: ");
            var companyId = Helpers.getId();
            var companyToShowPerson = companyService.Companies.FirstOrDefault(x => x.Id == companyId);
            if (companyToShowPerson != null)
            {
                Console.WriteLine("Id / Imię / Nazwisko / Telefon / E-Mail");
                foreach (var person in companyToShowPerson.Staff)
                    Console.WriteLine($"{person.Id} / {person.FirstName} / {person.LastName} / {person.PhoneNumber} / {person.Mail}.");

            }
        }
    }
}
