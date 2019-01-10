using Lab9.Model.Util;

namespace Lab9.Model.Expressions
{
    public class ConstExp: IExpression
    {
        private int value;

        public ConstExp(int value)
        {
            this.value = value;
        }

        string IExpression.toString()
        {
            return value.ToString();
        }

        int IExpression.evaluate(SymTable<string, int> symTable)
        {
            return value;
        }
    }
}