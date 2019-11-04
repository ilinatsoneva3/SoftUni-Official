using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hospital
{
   public  class Doctor
    {
        private List<string> patients;

        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.patients = new List<string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void AddPatient(string name)
        {
            this.patients.Add(name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in patients.OrderBy(x=>x))
            {
                sb.AppendLine(patient);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
