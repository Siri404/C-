using System.Text;
using Lab9.Model.Expressions;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class AssignStmt: IStmt
    {
        private string varName;
        private IExpression exp;

        public AssignStmt(string varName, IExpression exp)
        {
            this.varName = varName;
            this.exp = exp;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(varName)
                .Append("=")
                .Append(exp.toString());
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            SymTable<string, int> symTable = programState.getSymTable();
            if (symTable.ContainsKey(varName))
            {
                symTable[varName] = exp.evaluate(symTable);
            }
            else
            {
                symTable.Add(varName, exp.evaluate(symTable));
            }

            return null;
        }
    }
}