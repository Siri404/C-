using Lab9.Model.Util;

namespace Lab9.Model.Expressions
{
    public interface IExpression
    {
        string toString();
        int evaluate(SymTable<string, int> symTable);
    }
}