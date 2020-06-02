namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private string command;
        private ManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while ((command = Console.ReadLine())!="Exit")
            {
                var commandArgs = command.Split();
                var result = string.Empty;

                try
                {
                    switch (commandArgs[0])
                    {
                        case "AddPlayer":
                           result =  this.managerController.AddPlayer(commandArgs[1], commandArgs[2]);
                            break;
                        case "AddCard":
                            result = this.managerController.AddCard(commandArgs[1], commandArgs[2]);
                            break;
                        case "AddPlayerCard":
                            result = this.managerController.AddPlayerCard(commandArgs[1], commandArgs[2]);
                            break;
                        case "Fight":
                            result = this.managerController.Fight(commandArgs[1], commandArgs[2]);
                            break;
                        case "Report":
                            result = this.managerController.Report();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
