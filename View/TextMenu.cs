using System;
using System.Collections.Generic;

namespace Lab9.View
{
    public class TextMenu
    {
        private Dictionary<string, Command> cmds;

        public TextMenu(Dictionary<string, Command> cmds)
        {
            this.cmds = cmds;
        }

        public void AddCommand(Command cmd)
        {
            cmds.Add(cmd.GetKey(), cmd);
        }

        public void printMenu()
        {
            Console.WriteLine("Available commands: ");
            foreach (Command cmd in cmds.Values)
            {
                String line = String.Format("Command {0}: {1}", cmd.GetKey(), cmd.GetDescription());
                Console.WriteLine(line);
            }
        }

        public List<string> getCommandList()
        {
            List<string> l = new List<String>();
            foreach (Command cmd in cmds.Values)
                l.Add(cmd.GetDescription());
            return l;
        }

        public void show()
        {
            while (true)
            {
                printMenu();
                Console.WriteLine("Input the command: ");
                string line = Console.ReadLine();
                if (line == null || !cmds.ContainsKey(line))
                {
                    Console.WriteLine("Invalid command\n");
                    continue;
                }
                else
                {
                    Command cmd = cmds[line];
                    cmd.Execute();
                }
            }
        }
    }
}