using System.Text;
using Lab9.Model.Expressions;

namespace Lab9.Model.Statements
{
    public class PrintStmt: IStmt
    {
        private IExpression exp;

        public PrintStmt(IExpression exp)
        {
            this.exp = exp;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("print(")
                .Append(exp.toString())
                .Append(")");
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            programState.getOutput().Add(exp.evaluate(programState.getSymTable()));
            return null;
        }
    }
}