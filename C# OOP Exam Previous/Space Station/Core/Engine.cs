namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.IO;
    using SpaceStation.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                var result = string.Empty;
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        result = controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var items = input.Skip(2).Take(input.Length - 2).ToArray();

                        result = controller.AddPlanet(input[1], items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        result = controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        result = controller.ExplorePlanet(input[1]);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

                writer.WriteLine(result);
            }
        }
    }
}
