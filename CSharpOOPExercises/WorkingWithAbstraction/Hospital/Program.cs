using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            //department doctor patient
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var doctors = new Dictionary<string, Doctor>();
            var departments = new Dictionary<string, Department>();

            while (input[0]!="Output")
            {
                var departmentName = input[0];
                var doctorFirstName = input[1];
                var doctorLastName = input[2];
                var patientName = input[3];

                AddPatientToDoctorList(doctors, doctorFirstName, doctorLastName, patientName);
                AddPatientToDepartmentRoom(departments, departmentName, patientName);                                               
               
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (input[0]!="End")
            {
                PrintOutput(input, doctors, departments);
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

        }

        private static void PrintOutput(List<string> input, Dictionary<string, Doctor> doctors, Dictionary<string, Department> departments)
        {
            if (input.Count==1)
            {
                var departmentToPrint = departments[input[0]];
                Console.WriteLine(departmentToPrint);
            }
            else if (departments.ContainsKey(input[0]))
            {
                var departmentToPrint = departments[input[0]];
                var roomToPrint = int.Parse(input[1]);
                Console.WriteLine(departmentToPrint.PrintRoom(roomToPrint));
            }
            else
            {
                var doctor = doctors[input[0]];
                Console.WriteLine(doctor);
            }
        }

        private static void AddPatientToDepartmentRoom(Dictionary<string, Department> departments, string departmentName, string patientName)
        {
            if (!departments.ContainsKey(departmentName))
            {
                var department = new Department(departmentName);
                departments.Add(departmentName, department);
            }

            var currentDepartment = departments[departmentName];
            currentDepartment.AddPatient(patientName);

        }

        private static void AddPatientToDoctorList(Dictionary<string, Doctor> doctors, string doctorFirstName, 
            string doctorLastName, string patientName)
        {
            if (!doctors.ContainsKey(doctorFirstName))
            {
                var doctor = new Doctor(doctorFirstName, doctorLastName);
                doctors.Add(doctorFirstName, doctor);
            }

            var currentDoctor = doctors[doctorFirstName];
            currentDoctor.AddPatient(patientName);

        }
    }
}
