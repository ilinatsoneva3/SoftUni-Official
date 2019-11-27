namespace CommandPattern.Commands
{
    using CommandPattern.Core.Contracts;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[0];

            return $"Hello, {name}";
        }
    }
}
