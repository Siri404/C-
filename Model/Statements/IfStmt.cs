using System;
using System.Text;
using Lab9.Model.Expressions;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class IfStmt: IStmt
    {
        private IExpression exp;
        private IStmt thenStmt, elseStmt;

        public IfStmt(IExpression exp, IStmt thenStmt, IStmt elseStmt)
        {
            this.exp = exp;
            this.thenStmt = thenStmt;
            this.elseStmt = elseStmt;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("if(")
                .Append(exp.toString())
                .Append(")then(")
                .Append(thenStmt.toString())
                .Append(")else(")
                .Append(elseStmt.toString())
                .Append(")");
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            ExeStack<IStmt> exeStack = programState.getExeStack();

            if (exp.evaluate(programState.getSymTable()) != 0)
            {
                exeStack.Push(thenStmt);
            }
            else
            {
                exeStack.Push(elseStmt);
            }

            return null;
        }
    }
}