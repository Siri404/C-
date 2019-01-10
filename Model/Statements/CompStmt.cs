using System;
using System.Text;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class CompStmt: IStmt
    {
        private IStmt st1, st2;

        public CompStmt(IStmt st1, IStmt st2)
        {
            this.st1 = st1;
            this.st2 = st2;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(st1.toString())
                .Append(";")
                .Append(st2.toString());
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            ExeStack<IStmt> exeStack = programState.getExeStack();
            exeStack.Push(st2);
            exeStack.Push(st1);
            return null;
        }
    }
}