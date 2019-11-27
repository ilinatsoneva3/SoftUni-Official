namespace CommandPattern.Core.Contracts
{
    using CommandPattern.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split();

            string commandName = (inputArgs[0] + "Command").ToLower();
            var executableInput = inputArgs.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType==null)
            {
                throw new ArgumentException("Invalid command name");
            }

            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;

            if (instanceType==null)
            {
                throw new ArgumentException("Invalid command name");

            }

            var result = instanceType.Execute(executableInput);

            return result;
        }
    }
}
