namespace MilitaryElite
{
    using MilitaryElite.Controller;
    using MilitaryElite.Enums;
    using MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    var input = command.Split().ToList();

                    var result = this.Parse(input);

                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                }
               
                command = Console.ReadLine();
            }
        }

        private string Parse(List<string> input)
        {
            var soldierType = input[0];
            var soldierId = int.Parse(input[1]);
            var firstName = input[2];
            var lastName = input[3];
            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                var salary = decimal.Parse(input[4]);
                soldier = new Private(soldierId, firstName, lastName, salary);

            }
            else if (soldierType == "LieutenantGeneral")
            {
                var salary = decimal.Parse(input[4]);
                var listOfPrivates = new List<IPrivate>();

                for (int i = 5; i < input.Count; i++)
                {
                    IPrivate currentPrivate = (IPrivate)soldiers[int.Parse(input[i])];
                    listOfPrivates.Add(currentPrivate);
                }

                soldier = new LieutenantGeneral(soldierId, firstName, lastName, salary, listOfPrivates);

            }
            else if (soldierType == "Engineer")
            {
                var salary = decimal.Parse(input[4]);
                var isCorps = Enum.TryParse<Corps>(input[5], out Corps corps);

                if (!isCorps)
                {
                    throw new Exception();
                }

                var repairs = new List<IRepair>();

                for (int i = 6; i < input.Count; i += 2)
                {
                    var repairPart = input[i];
                    var repairHours = int.Parse(input[i + 1]);
                    var repair = new Repair(repairPart, repairHours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(soldierId, firstName, lastName, salary, corps, repairs);
            }
            else if (soldierType == "Commando")
            {
                var salary = decimal.Parse(input[4]);
                var isCorps = Enum.TryParse<Corps>(input[5], out Corps corps);

                if (!isCorps)
                {
                    throw new Exception();
                }

                var missions = new List<IMission>();

                for (int i = 6; i < input.Count; i += 2)
                {
                    var missionName = input[i];
                    var state = input[i + 1];

                    var isState = Enum.TryParse<State>(state, out State finalState);

                    if (!isState)
                    {
                        continue;
                    }

                    var mission = new Mission(missionName, finalState);
                    missions.Add(mission);
                }

                soldier = new Commando(soldierId, firstName, lastName, salary, corps, missions);

            }
            else if (soldierType == "Spy")
            {
                var codeNumber = int.Parse(input[4]);
                soldier = new Spy(soldierId, firstName, lastName, codeNumber);
            }

            soldiers.Add(soldierId, soldier);
            return soldier.ToString();
        }
    }
}
