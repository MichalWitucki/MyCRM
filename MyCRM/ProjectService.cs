using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            Projects.Add(new Project() { Id = 1, City = "Bytom", VoivodeshipId = 12, Street = "Konstytucji", StatusId = 3, RepId = 2, ContractorId = 0, EngineeringOfficeId = 0, IssuingAgencyId = 0 });

        }
        public void ProjectServiceMenuAction(CompanyService companyService)
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
                        AddNewProject(companyService);
                        break;
                    case '2':
                        EditProject();
                        break;
                    case '3':
                        RemoveProject();
                        break;
                    case '4':
                        ShowProjectList(companyService);
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

        private void AddNewProject(CompanyService companyService)
        {
            Project project = new Project();
            Console.WriteLine("Dodawanie nowego projektu.");
            foreach (var voivodeship in Helpers.voivodeships)
                Console.Write($"{voivodeship.Key} = {voivodeship.Value}, ");
            Console.WriteLine();
            Console.Write("Id województwa: ");
            if (int.TryParse(Console.ReadLine(), out int voivodeshipId))
                project.VoivodeshipId = voivodeshipId;
            else
                Console.WriteLine("Błędne Id województwa. Województwo nie zostało ustawione.");
            Console.Write("Miejscowość: ");
            project.City = Console.ReadLine();            
            Console.Write("Ulica: ");
            project.Street = Console.ReadLine();
            foreach (var status in Helpers.statuses)
                Console.Write($"{status.Key} = {status.Value}, ");
            Console.WriteLine();
            Console.Write("Id statusu: ");
            if (int.TryParse(Console.ReadLine(), out int statusId))
                project.StatusId = statusId;
            else
                Console.WriteLine("Błędne Id statusu. Status nie został ustawiony.");
            var repList = companyService.Companies.ElementAt(0).Staff.FindAll(x => x.Id == 2);
            foreach (var rep in repList)
                Console.Write($"{rep.Id} {rep.FirstName} {rep.LastName}, ");
            Console.WriteLine();
            Console.Write("Id przedstawiciela: ");
            if (int.TryParse(Console.ReadLine(), out int repId))
                project.RepId = repId;
            else
                Console.WriteLine("Błędne Id przedstawiciela. Przedstawiciel nie został ustawiony.");
            foreach (var company in companyService.Companies)
                Console.Write($"{company.Id} {company.Name} {company.City}, ");
            Console.WriteLine();
            Console.Write("Id wykonawcy: ");
            if (int.TryParse(Console.ReadLine(), out int contractorId))
                project.ContractorId = contractorId;
            else
                Console.WriteLine("Błędne Id wykonawcy. Wykonawca nie został ustawiony.");
            Console.Write("Id zamawiającego: ");
            if (int.TryParse(Console.ReadLine(), out int issuingAgencyId))
                project.IssuingAgencyId = issuingAgencyId;
            else
                Console.WriteLine("Błędne Id zamawiającego. Zamawiający nie został ustawiony.");
            Console.Write("Id biura projektowego: ");
            if (int.TryParse(Console.ReadLine(), out int engineeringOfficeId))
                project.EngineeringOfficeId = engineeringOfficeId;
            else
                Console.WriteLine("Błędne Id biura projektowego. Biuro projektow nie zostało ustawione.");
            if (Projects.Count == 0)
                project.Id = 1;
            else
                project.Id = Projects.Last().Id + 1;

            Projects.Add(project);
            Console.WriteLine($"Dodano nowy projekt {project.City}, {project.Street} o Id {project.Id}.");
        }

        private void EditProject()
        {
            
        }

        private void RemoveProject()
        {
            
        }

        private void ShowProjectList(CompanyService companyService)
        {
            Console.WriteLine("Id / Województwo / Miasto / Ulica / Status / Przedstawiciel / Wykonawca / Zamawiający / Biuro Projektowe /");
            foreach (var project in Projects)
                Console.WriteLine($"{project.Id} / {Helpers.voivodeships[project.VoivodeshipId]} / {project.City} " +
                    $"/ {project.Street} / {Helpers.statuses[project.StatusId]} / " +
                    $"{companyService.Companies.ElementAt(0).Staff.FirstOrDefault(x => x.Id == project.RepId).LastName} / " +
                    $"{companyService.Companies.FirstOrDefault(x => x.Id == project.ContractorId).Name} / " +
                    $"{companyService.Companies.FirstOrDefault(x => x.Id == project.IssuingAgencyId).Name} / " +
                    $"{companyService.Companies.FirstOrDefault(x => x.Id == project.EngineeringOfficeId).Name} /");
        }
    }
}
