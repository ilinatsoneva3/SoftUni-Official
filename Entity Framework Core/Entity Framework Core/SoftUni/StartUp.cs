namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = RemoveTown(context);
            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle").ToList();

            employees.ForEach(e => e.AddressId = null);

            var numOfAddresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle").Count();

            var listOfAddresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            context.RemoveRange(listOfAddresses);

            var town = context.Towns
                .Where(t => t.Name == "Seattle").FirstOrDefault();

            context.Remove(town);


            context.SaveChanges();

            var result = $"{numOfAddresses} addresses in Seattle were deleted";

            return result;
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.RemoveRange(employeesProjects);

            var project = context.Projects
                .Where(p => p.ProjectId == 2).FirstOrDefault();

            context.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            projects.ForEach(p => result.AppendLine(p));

            return result.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            if (!employees.Any())
            {
                return string.Empty;
            }

            var result = new StringBuilder();


            employees.ForEach(e =>
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})")
            );

            return result.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                           || e.Department.Name == "Tool Design"
                           || e.Department.Name == "Marketing"
                           || e.Department.Name == "Information Services");

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesUpdated = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employeesUpdated.ForEach(e =>
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})")
            );

            return result.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate.Date)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToList();

            foreach (var project in projects)
            {
                result.AppendLine($"{project.Name}");
                result.AppendLine($"{project.Description}");
                result.AppendLine($"{project.ProjectStartDate}");
            }

            return result.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle
                            })
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToList()
                })
                .ToList();

            foreach (var dept in departments)
            {
                result.AppendLine($"{dept.Name} - {dept.ManagerFirstName} {dept.ManagerLastName}");

                foreach (var empl in dept.Employees)
                {
                    result.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name).OrderBy(ep => ep).ToList()
                })
                .Single();


            result.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var pr in employee147.Projects)
            {
                result.AppendLine(pr);
            }

            return result.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = new StringBuilder();

            var listOfAddresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    Text = a.AddressText,
                    Town = a.Town.Name,
                    Population = a.Employees.Count
                })
                .ToList();

            listOfAddresses.ForEach(a =>
                result.AppendLine($"{a.Text}, {a.Town} - {a.Population} employees")
            );

            return result.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employyesProjects = context.Employees
                .Where(e => e.EmployeesProjects
                                    .Any(ep => ep.Project.StartDate.Year >= 2001
                                        && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            ProjectEndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        })
                })
                .ToList();

            foreach (var e in employyesProjects)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var project in e.Project)
                {
                    result.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
                }
            }

            return result.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var result = new StringBuilder();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees.Where(e => e.LastName == "Nakov").First();

            employee.Address = address;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            addresses.ForEach(a =>
                    result.AppendLine(a)
                );

            return result.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .Where(e => e.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            employees.ForEach(e =>
                    result.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:F2}")
                );

            return result.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            employees.ForEach(e =>
                 result.AppendLine($"{e.FirstName} - {e.Salary:F2}")
            );

            return result.ToString().Trim();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employeesList = context.Employees
                .Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            employeesList.ForEach(e =>
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}")
                );

            return result.ToString().Trim();
        }
    }
}
