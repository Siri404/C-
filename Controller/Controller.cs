using System;
using System.Linq;
using Lab9.Model;
using Lab9.Model.Statements;
using Lab9.Model.Util;
using Lab9.Repository;

namespace Lab9.Controller
{
    public class Controller
    {
        private IRepository repo;
        public Controller(IRepository repo)
        {
            this.repo = repo;
        }

        public void SetMain(ProgramState prgState)
        {
            this.repo.GetPrgList().Clear();
            this.repo.GetPrgList().Add(prgState);
        }

        public ProgramState OneStep(ProgramState prgState)
        {
            ExeStack<IStmt> exeStack = prgState.getExeStack();
            if (exeStack.Count == 0)
                throw new Exception("Empty execution stack!\n");
            return exeStack.Pop().execute(prgState);
        }

        public void AllSteps()
        {
            ProgramState prgState = this.repo.GetPrgList().ElementAt(0);
            repo.LogPrgStateExec(prgState);
            while (prgState.getExeStack().Count > 0)
            {
                OneStep(prgState);
                repo.LogPrgStateExec(prgState);
            }
        }
    }
}