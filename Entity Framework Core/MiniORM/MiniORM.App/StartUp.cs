namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    public class StartUp
    {
        static void Main(string[] args)
        {
           var connectionString = @"Server=DESKTOP-URSLOO9\SQLEXPRESS;Database=MiniORM;Integrated Security=true";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Peshov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Ivan";

            context.SaveChanges();
        }
    }
}
