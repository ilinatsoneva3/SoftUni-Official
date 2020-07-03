namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            //Employees full information

            // var result = GetEmployeesFullInformation(context);
            // Console.WriteLine(result);

            // Employees with Salary Over 50 000
            // var result = GetEmployeesWithSalaryOver50000(context);
            // Console.WriteLine(result);

            // Employees from Research and Development
            //var result = GetEmployeesFromResearchAndDevelopment(context);
            //Console.WriteLine(result);

            //Adding a New Address and Updating Employee
           //var result = AddNewAddressToEmployee(context);
           //Console.WriteLine(result);

            //Employees and projects


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

            employees.ForEach(e=>
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
