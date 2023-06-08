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
            Companies.Add(new Company() { Id = 1, City = "aaaa", Street = "aaaa", Name = "AAAA" });
            Companies.Add(new Company() { Id = 2, City = "bbbb", Street = "bbbb", Name = "BBBB" });
            Companies.Add(new Company() { Id = 3, City = "cccc", Street = "cccc", Name = "CCCC" });
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
        private int getId()
        {
            var userId = Console.ReadLine();
            if (int.TryParse(userId, out int id))
                return id;
            else
                return 0;
        }
        private void AddNewCompany()
        {
            Company company = new Company();
            Console.WriteLine("Dodawanie nowej firmy.");
            Console.Write("Nazwa firmy: ");
            company.Name = Console.ReadLine();
            Console.Write("Id województwa: ");
 
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
            var editId = getId();
            var editCompany = Companies.FirstOrDefault(x => x.Id == editId);
            if (editCompany != null)
            {
                Console.Write("Nazwa firmy: ");
                editCompany.Name = Console.ReadLine();
                //Console.Write("Województwo: ");
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
            var removeId = getId();
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
            Console.WriteLine("Id\tNazwa\t\t\tMiasto\t\t\tUlica");
            foreach (var company in Companies)
            {
                Console.WriteLine($"{company.Id}\t{company.Name}\t\t\t{company.City}\t\t\t{company.Street}.");
            }
        }
    }
}
