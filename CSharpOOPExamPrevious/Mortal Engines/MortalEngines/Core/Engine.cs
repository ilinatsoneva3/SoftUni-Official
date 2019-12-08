namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private string command;
        private MachinesManager machinesManager;
        private string result;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while ((command = Console.ReadLine()) != "Quit")
            {
                result = string.Empty;
                var commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "HirePilot":
                        try
                        {
                            result = machinesManager.HirePilot(commandArgs[1]);
                        }
                        catch (ArgumentNullException ae)
                        {
                            Console.WriteLine("Error: " + ae.Message);
                        }
                        break;
                    case "PilotReport":
                        result = machinesManager.PilotReport(commandArgs[1]);
                        break;
                    case "ManufactureTank":
                        try
                        {
                            var attack = double.Parse(commandArgs[2]);
                            var defense = double.Parse(commandArgs[2]);
                            result = machinesManager.ManufactureTank(commandArgs[1], attack, defense);                           
                        }
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine("Error: "+ ane.Message);
                        }
                        break;
                    case "ManufactureFighter":
                        try
                        {
                            var attack = double.Parse(commandArgs[2]);
                            var defense = double.Parse(commandArgs[3]);
                            result = machinesManager.ManufactureFighter(commandArgs[1], attack, defense);
                        }
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine("Error: " + ane.Message);
                        }
                        break;
                    case "MachineReport":
                        result = machinesManager.MachineReport(commandArgs[1]);
                        break;
                    case "AggressiveMode":
                        result = machinesManager.ToggleFighterAggressiveMode(commandArgs[1]);
                        break;
                    case "DefenseMode":
                        result = machinesManager.ToggleTankDefenseMode(commandArgs[1]);
                        break;
                    case "Engage":
                        try
                        {
                            result = machinesManager.EngageMachine(commandArgs[1], commandArgs[2]);
                        }
                        catch (NullReferenceException nre)
                        {
                            Console.WriteLine("Error: " + nre.Message);
                        }
                        break;
                    case "Attack":
                        try
                        {
                            result = machinesManager.AttackMachines(commandArgs[1], commandArgs[2]);
                        }
                        catch (NullReferenceException ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }                
            }
        }
    }
}
