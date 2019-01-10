using System;
using System.Text;
using Lab9.Model.Util;

namespace Lab9.Model.Expressions
{
    public class BooleanExp: IExpression
    {
        private IExpression op1;
        private IExpression op2;
        private string op;

        public BooleanExp(IExpression op1, IExpression op2, string op)
        {
            this.op = op;
            this.op1 = op1;
            this.op2 = op2;
        }

        string IExpression.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("(")
                .Append(op1.toString())
                .Append(op)
                .Append(op2.toString())
                .Append(")");
            return stringBuilder.ToString();
        }

        int IExpression.evaluate(SymTable<string, int> symTable)
        {
            
            int firstRes = op1.evaluate(symTable);
            int secondRes = op2.evaluate(symTable);

            switch (op)
            {
                case "<":
                    return firstRes < secondRes ? 1 : 0;

                case "<=":
                    return firstRes <= secondRes ? 1 : 0;

                case "==":
                    return firstRes == secondRes ? 1 : 0;

                case "!=":
                    return firstRes != secondRes ? 1 : 0;

                case ">=":
                    return firstRes >= secondRes ? 1 : 0;

                case ">":
                    return firstRes > secondRes ? 1 : 0;

                default:
                    throw new Exception("Invalid Operator!\n");
            }
        }
    }
}