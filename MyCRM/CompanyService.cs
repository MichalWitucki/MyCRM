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
        }
        public void CompanyServiceAction()
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
                        DeleteCompany();
                        break;
                    case '4':
                        ShowCompanyList();
                        break;
                    case '5':
                        exit = true;
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
            Console.Write("Województwo: ");
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

        }

        private void DeleteCompany()
        {

        }

        private void ShowCompanyList()
        {
            Console.WriteLine("Id\tNazwa\tMiasto\tUlica");
            foreach (var company in Companies)
            {
                Console.WriteLine($"{company.Id}\t{company.Name}\t{company.City}\t{company.Street}.");
            }
        }
    }
}
