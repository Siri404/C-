using System;
using System.Text;
using Lab9.Model.Util;

namespace Lab9.Model.Expressions
{
    public class ArithExp : IExpression
    {
        private IExpression op1, op2;
        private char op;

        public ArithExp(char op, IExpression op1, IExpression op2)
        {
            this.op = op;
            this.op1 = op1;
            this.op2 = op2;
        }

        string IExpression.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(op1.toString())
                .Append(op)
                .Append(op2.toString());
            return stringBuilder.ToString();
        }

        int IExpression.evaluate(SymTable<string, int> symTable)
        {
            int firstRes = op1.evaluate(symTable);
            int secondRes = op2.evaluate(symTable);
            switch (op)
            {
                case '+':
                    return firstRes + secondRes;

                case '-':
                    return firstRes - secondRes;

                case '*':
                    return firstRes * secondRes;

                case '/':
                    if (secondRes == 0) {
                        throw new DivideByZeroException("Division by 0!\n");
                    }

                    return firstRes / secondRes;

                default:
                    throw new Exception("Invalid Operator!\n");
            }
        }
    }
}