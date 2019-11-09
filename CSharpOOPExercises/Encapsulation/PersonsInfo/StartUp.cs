namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");
            var persons = new List<Person>();



            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }


        }
    }
}
