using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCRM
{
    public class CompanyService
    {
        public List<Company> Companies { get; set; }

        public CompanyService()
        {
            Companies = new List<Company>();
            Companies.Add(new Company() { Id = 0, City = "MyCity", VoivodeshipId = 12, Street = "Długa 11", Name = "MyCompany"});
            Companies.ElementAt(0).Staff.Add(new Person() { Id = 1, FirstName = "Adam", LastName = "Małysz", Mail = "am@mycompany.com", PhoneNumber = 123 });
        }
        public void CompanyServiceMenuAction()
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
                        AddNewCompany();
                        break;
                    case '2':
                        EditCompany();
                        break;
                    case '3':
                        RemoveCompany();
                        break;
                    case '4':
                        ShowCompanyList();
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

        private void AddNewCompany()
        {
            Company company = new Company();
            Console.WriteLine("Dodawanie nowej firmy.");
            Console.Write("Nazwa firmy: ");
            company.Name = Console.ReadLine();
            foreach (var voivodeship in Helpers.voivodeships)
                Console.Write($"{voivodeship.Key} = {voivodeship.Value}, ");
            Console.WriteLine();
            Console.Write("Id województwa: ");
            if (int.TryParse(Console.ReadLine(), out int voivodeshipId))
                company.VoivodeshipId = voivodeshipId;
            else
                Console.WriteLine("Błędne Id województwa. Województwo nie zostało ustawione.");
            Console.Write("Miasto: ");
            company.City = Console.ReadLine();
            Console.Write("Ulica: ");
            company.Street = Console.ReadLine();

            if (Companies.Count == 0)
                company.Id = 1;
            else
                company.Id = Companies.Last().Id + 1;

            Companies.Add(company);
            Console.WriteLine($"Dodano nową firmę {company.Name} o Id {company.Id}.");
        }


        private void EditCompany()
        {
            Console.WriteLine("Edycja firmy.");
            Console.Write("Podaj Id firmy do edycji: ");
            var editId = Helpers.getId();
            var editCompany = Companies.FirstOrDefault(x => x.Id == editId);
            if (editCompany != null)
            {
                Console.Write("Nazwa firmy: ");
                editCompany.Name = Console.ReadLine();
                foreach (var voivodeship in Helpers.voivodeships)
                    Console.Write($"{voivodeship.Key} = {voivodeship.Value}, ");
                Console.WriteLine();
                Console.Write("Id województwa: ");
                if (int.TryParse(Console.ReadLine(), out int voivodeshipId))
                    editCompany.VoivodeshipId = voivodeshipId;
                else
                    Console.WriteLine("Błędne Id województwa. Województwo nie zostało zmienione.");
                Console.Write("Miasto: ");
                editCompany.City = Console.ReadLine();
                Console.Write("Ulica: ");
                editCompany.Street = Console.ReadLine();
            }
            else
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }

        private void RemoveCompany()
        {
            Console.WriteLine("Usuwanie firmy.");
            Console.Write("Podaj Id firmy do usunięcia: ");
            var removeId = Helpers.getId();
            bool removed = false;
            foreach (var company in Companies)
            {
                if (company.Id == removeId)
                {
                    Companies.Remove(company);
                    Console.WriteLine($"Usunięto firmę {company.Name} o Id {company.Id}.");
                    removed = true;
                    break;
                }
            }
            if (!removed)
                Console.WriteLine("Nie znaleziono firmy o podanym Id.");
        }

        private void ShowCompanyList()
        {
            Console.WriteLine("Id / Nazwa / Województwo / Miasto / Ulica");
            foreach (var company in Companies)
                Console.WriteLine($"{company.Id} / {company.Name} / {Helpers.voivodeships[company.VoivodeshipId]} / {company.City} / {company.Street}.");
        }
    }
}
