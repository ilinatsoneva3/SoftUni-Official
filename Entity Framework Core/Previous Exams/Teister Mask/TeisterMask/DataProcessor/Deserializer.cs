namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var result = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            var projects = new List<Project>();

            var projectsDTO = serializer.Deserialize(new StringReader(xmlString)) as ImportProjectDto[];

            foreach (var projectDTO in projectsDTO)
            {
                if (!IsValid(projectDTO))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;

                var isOpenDateValid = DateTime.TryParseExact(projectDTO.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = projectDTO.Name,
                    OpenDate = openDate
                };

                DateTime? dueDate;
                if (!String.IsNullOrEmpty(projectDTO.DueDate))
                {
                    DateTime projectDueDate;
                    var isDueDateValid = DateTime.TryParseExact(projectDTO.DueDate, "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);

                    if (!isDueDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = projectDueDate;
                }
                else
                {
                    dueDate = null;
                }

                project.DueDate = dueDate;

                foreach (var taskDto in projectDTO.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    DateTime taskDueDate;

                    var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);


                    var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    var isTaskDueDateAfterProjectDueDate = taskDueDate > project.DueDate; //if false, dates are valid


                    if (!isTaskOpenDateValid || !isTaskDueDateValid)

                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate.HasValue)
                    {
                        if (taskDueDate > project.DueDate.Value)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                result.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var result = new StringBuilder();
            var employees = new List<Employee>();
            var employeesDto = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.UserName,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = context
                        .Tasks
                        .FirstOrDefault(t => t.Id == taskId);

                    if (task is null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        Task = task
                    });
                }

                employees.Add(employee);
                result.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}