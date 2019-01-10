using System;

namespace Lab9.View
{
    public class RunCommand: Command
    {
        private Controller.Controller ctrl;

        public RunCommand(string key, string desciption, Controller.Controller ctrl) : base(key, desciption)
        {
            this.ctrl = ctrl;
        }

        public override void Execute()
        {
            try
            {
                ctrl.AllSteps();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}