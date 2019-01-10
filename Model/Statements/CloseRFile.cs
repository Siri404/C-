using System;
using System.IO;
using System.Text;
using Lab9.Model.Expressions;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class CloseRFile: IStmt
    {
        private IExpression exp_file_id;

        public CloseRFile(IExpression exp_file_id)
        {
            this.exp_file_id = exp_file_id;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("CloseFile(")
                .Append(exp_file_id.toString())
                .Append(")");
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            FileTable fileTable = programState.getFileTable();
            SymTable<string, int> symTable = programState.getSymTable();

            int TextReader_id = exp_file_id.evaluate(symTable);
            if(!fileTable.ContainsKey(TextReader_id)) throw new Exception("Invalid file id!\n");
            TextReader textReader = fileTable[TextReader_id].Item2;
            textReader.Close();
            
            fileTable.Remove(TextReader_id);
            return null;
        }
    }
}