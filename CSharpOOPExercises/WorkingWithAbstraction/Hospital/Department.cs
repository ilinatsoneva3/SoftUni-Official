using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hospital
{
    public class Department
    {
        private const int totalCapacity = 20;
        private const int roomCapacity = 3;
        private Dictionary<int, List<string>> patients;
        private int numberOfRooms = 1;

        public Department(string name)
        {
            this.patients = new Dictionary<int, List<string>> ();
            this.patients[numberOfRooms] = new List<string>();
        }
        public string Name { get; set; }

        public void AddPatient(string name)
        {
            CheckCapacity(this.patients);
            this.patients[this.numberOfRooms].Add(name);
        }

        public string PrintRoom(int n)
        {
            StringBuilder sb = new StringBuilder();
            var roomToPrint = this.patients[n];

            foreach (var patient in roomToPrint.OrderBy(x=>x))
            {
                sb.AppendLine(patient);
            }

            return sb.ToString().TrimEnd();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.patients.Values)
            {
                foreach (var patient in room)
                {
                    sb.AppendLine(patient);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private void CheckCapacity(Dictionary<int, List<string>> patients)
        {
            if (this.patients[this.numberOfRooms].Count== roomCapacity)
            {
                this.numberOfRooms++;
                this.patients[this.numberOfRooms] = new List<string>();
            }
        }        
    }
}
