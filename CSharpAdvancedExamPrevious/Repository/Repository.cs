namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Repository
    {
        private Dictionary<int, Person> people;
        private int id;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => this.people.Count;

        public void Add(Person person)
        {
            this.people.Add(id++, person);
        }

        public Person Get(int index)
        {
            Person person = this.people[index];
            return person;
        }

        public bool Update(int id, Person person)
        {
            if (!IsValidID(id))
            {
                return false;
            }

            Person searchedPerson = this.people[id];
            searchedPerson.Name = person.Name;
            searchedPerson.Age = person.Age;
            searchedPerson.Birthdate = person.Birthdate;
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsValidID(id))
            {
                return false;
            }

            this.people.Remove(id);
            return true;
        }

        private bool IsValidID(int id)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            return true;
        }
    }
}
