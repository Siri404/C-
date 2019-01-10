using System;
using Lab9.Model.Util;

namespace Lab9.Model.Expressions
{
    public class VarExp: IExpression
    {
        private string name;

        public VarExp(string name)
        {
            this.name = name;
        }

        string IExpression.toString()
        {
            return name;
        }

        int IExpression.evaluate(SymTable<string, int> symTable)
        {
            if (symTable.ContainsKey(name))
            {
                return symTable[name];
            }
            else
            {
                throw new Exception("Non-existent variable!\n");
            }
        }
    }
}