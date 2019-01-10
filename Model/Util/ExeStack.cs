using System.Linq.Expressions;
using System.Text;
using Lab9.Model.Statements;
namespace Lab9.Model.Util
{
    public class ExeStack<T>: MyStack<IStmt>
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IStmt item in this)
            {
                stringBuilder
                    .Append(item.toString())
                    .AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}