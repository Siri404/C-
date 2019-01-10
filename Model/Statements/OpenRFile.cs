using System;
using System.IO;
using System.Text;
using Lab9.Model.Util;

namespace Lab9.Model.Statements
{
    public class OpenRFile: IStmt
    {
        private string fileName, var_file_id;

        public OpenRFile(string var_file_id, string fileName)
        {
            this.fileName = fileName;
            this.var_file_id = var_file_id;
        }

        string IStmt.toString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("Open(")
                .Append(var_file_id)
                .Append(",'")
                .Append(fileName)
                .Append("')");
            return stringBuilder.ToString();
        }

        ProgramState IStmt.execute(ProgramState programState)
        {
            FileTable fileTable = programState.getFileTable();
            SymTable<string, int> symTable = programState.getSymTable();

            bool found = false;
            foreach (Tuple<string, TextReader> t in fileTable.Values)
            {
                if (t.Item1.Equals(fileName))
                {
                    found = true;
                    break;
                }
            }
            
            if(found) throw new Exception("File already open!\n");
            if(symTable.ContainsKey(var_file_id)) throw new Exception("File id already exists!\n");

            TextReader textReader = File.OpenText(fileName);
            int id = fileTable.Add(new Tuple<string, TextReader>(fileName, textReader));
            symTable.Add(var_file_id, id);
            return null;
        }
    }
}