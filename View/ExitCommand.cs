using System;

namespace Lab9.View
{
    public class ExitCommand: Command
    {
        public ExitCommand(string key, string description) : base(key, description)
        { }

        public override void Execute()
        {
            Console.WriteLine("Program terminated");
            Environment.Exit(0);
        }
    }
}