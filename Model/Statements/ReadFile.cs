using System;
using System.IO;
using System.Text;
using Lab9.Model.Expressions;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class ReadFile: IStmt
    {
        private string varName;
        private IExpression exp_file_id;

        public ReadFile(IExpression exp_file_id, string varName)
        {
            this.varName = varName;
            this.exp_file_id = exp_file_id;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("Read(")
                .Append(exp_file_id.toString())
                .Append(",")
                .Append(varName)
                .Append(")");
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            FileTable fileTable = programState.getFileTable();
            SymTable<string, int> symTable= programState.getSymTable();

            int id = exp_file_id.evaluate(symTable);
            if(!fileTable.ContainsKey(id)) throw new Exception("Invalid text reader id!\n");
            TextReader textReader = fileTable[id].Item2;

            string line = textReader.ReadLine();
            int value;
            if (line == null)
            {
                value = 0;
            }
            else
            {
                value = int.Parse(line);
            }

            if (symTable.ContainsKey(varName))
            {
                symTable[varName] = value;
            }
            else
            {
                symTable.Add(varName, value);
            }

            return null;
        }
    }
}