namespace MXGP.Core
{
    using System;
    using System.IO;

    public class Engine
    {
        private string input;
        private ChampionshipController controller;

        public Engine()
        {
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            while ((input=Console.ReadLine()) !="End")
            {
                var inputArgs = input.Split();
                var result = string.Empty;

                try
                {
                    switch (inputArgs[0])
                    {
                        case "CreateRider":
                            result = this.controller.CreateRider(inputArgs[1]);
                            break;
                        case "CreateMotorcycle":
                            result = this.controller.CreateMotorcycle(inputArgs[1], inputArgs[2], int.Parse(inputArgs[3]));
                            break;
                        case "AddMotorcycleToRider":
                            result = this.controller.AddMotorcycleToRider(inputArgs[1], inputArgs[2]);
                            break;
                        case "AddRiderToRace":
                            result = this.controller.AddRiderToRace(inputArgs[1], inputArgs[2]);
                            break;
                        case "CreateRace":
                            result = this.controller.CreateRace(inputArgs[1], int.Parse(inputArgs[2]));
                            break;
                        case "StartRace":
                            result = this.controller.StartRace(inputArgs[1]);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                Console.WriteLine(result);
            }
        }
    }
}
